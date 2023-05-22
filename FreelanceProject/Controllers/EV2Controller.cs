using FreelanceProject.API.Util;
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;
using FreelanceProject.DAL.Repos.Mahmoud.EmergencyV2;
using FreelanceProject.DAL.Repos.Mona.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EV2Controller : ControllerBase
    {
        private readonly IEmergencyV2 _emContext;
        private readonly IUserRepo _userContext;
        public EV2Controller(IEmergencyV2 emergencyV2, IUserRepo userRepo)
        {
            _emContext = emergencyV2;
            _userContext = userRepo;
        }
        [HttpGet]
        public ActionResult<List<EmergencyV2DTosRead>> GetAll() {
            var emergency = _emContext.GetAll();

            var newData = emergency.Select(emergency => new EmergencyV2DTosRead
            {
                id = emergency.Id,
                CreatedAt = emergency.CreatedAt,
                Status = emergency.Status,
                ApprovedBy = emergency.ApprovedBy,
                UserID = emergency.ApplicationUserID!,
                //Location = new LocationDtio { Latitude = emergency.Latitude, Longitude = emergency.Logntitue },
                Username = emergency.User!.UserName!,
                //Emergencies = emergency.User_Emergencies!.Select(em => new EmergencyDtoList
                //{
                //    CaseTitle = em.CaseTitle,
                //    Q_As = em.Questions_Answers!.Select(qa => new QandADto { Answer = qa.Answer, Question = qa.Question }).ToList()
                //}).ToList()
            }).ToList();

            return Ok(newData);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<ActionResult<EmergencyV2DTosRead>> GetOne(int id)
        {
            var emergency = _emContext.GetByID(id);
            ApprovedByUserDto? appDto = null;

            if (emergency is null)
            {
                return BadRequest("the emergency wasn't found");
            }

            if (emergency.ApprovedBy is not null)
            {
                var ApprovedUser = await _userContext.GetById(emergency.ApprovedBy)!;
                appDto = new ApprovedByUserDto { UserID = ApprovedUser?.Id, Email = ApprovedUser?.Email, Username = ApprovedUser?.UserName };
            }

            var newData =  new EmergencyV2DTosRead
            {
                id = emergency.Id,
                CreatedAt = emergency.CreatedAt,
                Status = emergency.Status,
                ApprovedBy = emergency.ApprovedBy,
                ApprovedByUser = appDto,
                UserID = emergency.ApplicationUserID!,
                Location = new LocationDtio { Latitude = emergency.Latitude, Longitude = emergency.Logntitue },
                Username = emergency.User!.UserName!,
                Emergencies = emergency.User_Emergencies!.Select(em => new EmergencyDtoList
                {
                    CaseTitle = em.CaseTitle,
                    Q_As = em.Questions_Answers!.Select(qa => new QandADto { Answer = qa.Answer, Question = qa.Question }).ToList()
                }).ToList()
            };

            return Ok(newData);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<List<EmergencyV2DTosRead>> GetByUserID(Guid id)
        {
            var emergency = _emContext.GetByUserID(id.ToString());

            if(emergency== null) { return NotFound(new GeneralResponse("No Such User ID")); }

            var newData = emergency.Select(emergency => new EmergencyV2DTosRead
            {
                id=emergency.Id,
                UserID=emergency.ApplicationUserID!,
                Location = new LocationDtio { Latitude = emergency.Latitude, Longitude = emergency.Logntitue },
                Status = emergency.Status,
                ApprovedBy= emergency.ApprovedBy,
                Username = emergency.User!.UserName!,
                Emergencies = emergency.User_Emergencies!.Select(em => new EmergencyDtoList
                {
                    CaseTitle = em.CaseTitle,
                    Q_As = em.Questions_Answers!.Select(qa => new QandADto { Answer = qa.Answer, Question = qa.Question }).ToList()
                }).ToList()
            }).ToList();

            return Ok(newData);
        }


        [HttpPost]
        public ActionResult<EmergencyV2DTosRead> Create(EmergencyV2DTosRead evs)
        {
          //  var user = _userContext.GetByUsername(evs.Username);

            //if(user is null) { return NotFound(new GeneralResponse("no such username")); }

            var newdata = new User_Emergency
            {   
           

                Latitude =  evs.Location!.Latitude ,
                CreatedAt = (DateTime.Now).ToString("hh:mm tt"),
                Logntitue= evs.Location!.Longitude,
                ApplicationUserID = evs.UserID,
                ApprovedBy= evs.ApprovedBy,
                Status= evs.Status,
                User_Emergencies = evs.Emergencies!.Select(e => new EmergencyV2
                {
                    CaseTitle = e.CaseTitle,
                    Questions_Answers = e.Q_As.Select(q => new Questions_Answers { CastTitle = e.CaseTitle, Answer = q.Answer, Question = q.Question }).ToList()

                }).ToList(),
            };

            _emContext.Add(newdata);

            return Ok("record was created");
        }


        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<EmergencyV2DTosRead> Edit([FromBody] EmergencyV2DTosRead evs , int id)
        {
            var oldata = _emContext.GetByID(id);
            var user = _userContext.GetByUsername(evs.Username);

            if(oldata == null) { return NotFound(new GeneralResponse("No Such emergency exists")); }

            oldata.Logntitue = evs.Location!.Longitude;
            oldata.Latitude = evs.Location!.Latitude;

            oldata.ApplicationUserID = user!.Id;
            oldata.User_Emergencies = evs.Emergencies!.Select(e => new EmergencyV2
            {
                CaseTitle = e.CaseTitle,
                Questions_Answers = e.Q_As.Select(q => new Questions_Answers { CastTitle = e.CaseTitle, Answer = q.Answer, Question = q.Question }).ToList()

            }).ToList();
            

            _emContext.Save();

            return Ok("record was created");
        }

        [HttpPost]
        [Route("Visibility")]

        public IActionResult GetVisibility(VisibilityDto VDto)
        {
            var data = _emContext.GetUserVisibility(VDto.UserID);

            if (data.IsNullOrEmpty()) { return Ok(); }

           
            return Ok(data.Select(en => new VisibilityDtoResult
            {
                E_ID = en.User_EmergencyID,
                UserID = en.UserID,
                Status = en.StatusPart
            }));
        }

        [HttpPatch]
        [Route("status/{id:int}")]
        public async Task<ActionResult<EmergencyStatus>> EditStatus( int id , [FromBody] EmergencyStatus status)
        {

            //the relations code
            var oldata = _emContext.GetByID(id);

           

            if (oldata is null)
            {
                return NotFound("no such record exists");
            }

            var user = await _userContext.GetById(status.UserID);

            if(user is null) { return NotFound("User DOesnt exist"); }



            _emContext.ChangeStatusBy(user, status.newStatus, oldata);
        //    oldata.SeenBy!.Add(await _userContext.GetById(status.UserID));

            if(status.newStatus == Status.active)
            {
                oldata.Status = status.newStatus;
                oldata.ApprovedBy = user.Id;
                oldata.ApprovedByUser = await _userContext.GetById(user.Id);
               
            }
            else if(status.newStatus == Status.denied)
            {
                oldata.Status = Status.not_seen;
                oldata.ApprovedBy = null;
            }
            _emContext.Save();

            #region Getting the visibilityData for the Update

            var data = _emContext.GetUserVisibility(status.UserID);

            if (data.IsNullOrEmpty()) { return Ok(); }

            var Visibility_list = data.Select(en => new VisibilityDtoResult
            {
                E_ID = en.User_EmergencyID,
                UserID = en.UserID,
                Status = en.StatusPart
            });

            #endregion

            #region Getting all User_Ems for the visibility update 

            var emergency = _emContext.GetAll();

            var newData = emergency.Select(emergency => new EmergencyV2DTosRead
            {
                id = emergency.Id,
                CreatedAt = emergency.CreatedAt,
                Status = emergency.Status,
                ApprovedBy = emergency.ApprovedBy,
                UserID = emergency.ApplicationUserID!,
                Location = new LocationDtio { Latitude = emergency.Latitude, Longitude = emergency.Logntitue },
                Username = emergency.User!.UserName!,
                Emergencies = emergency.User_Emergencies!.Select(em => new EmergencyDtoList
                {
                    CaseTitle = em.CaseTitle,
                    Q_As = em.Questions_Answers!.Select(qa => new QandADto { Answer = qa.Answer, Question = qa.Question }).ToList()
                })
            .ToList()
            });

            #endregion


            return Ok(new VisibilityDtoWithData
            {
                Data = newData.ToList(),
                Visibility = Visibility_list.ToList()
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<EmergencyV2DTosRead> Delete([FromBody] EmergencyV2DTosRead evs, int id)
        {
            var oldata = _emContext.GetByID(id);
            var user = _userContext.GetByUsername(evs.Username);

            if (oldata == null) { return NotFound(new GeneralResponse("No Such emergency exists")); }

           _emContext.Remove(oldata);


            _emContext.Save();

            return Ok("record was Deleted");
        }
    }
}
