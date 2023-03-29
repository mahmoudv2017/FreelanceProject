
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mona;
using FreelanceProject.DAL.Repos.Mona.Emergency;
using FreelanceProject.DAL.Repos.Mona.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyController : ControllerBase
    {
        private readonly IEmergencyRepo  _emergencyRepo;

        public EmergencyController(IEmergencyRepo emergencyRepo)
        {
            _emergencyRepo = emergencyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emergency = await _emergencyRepo.GetAll();
            return Ok(emergency);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Emergencys>> GetById(int id)
        {
            var emergency = await _emergencyRepo.GetById(id);
            if (emergency == null)
            {
                return NotFound($"No Emergency With Id {id}");
            }
            return Ok(emergency);
        }
        [HttpPost]
        public async Task<ActionResult> Create(EmergencyDto emergencyDto)
        {
            var emergency = new Emergencys() 
            {
                Address=emergencyDto.Address,
                CaseID=emergencyDto.CaseID,
                CH_Body=emergencyDto.CH_Body,
                CH_Id=emergencyDto.CH_Id,
                Q_Body= emergencyDto.Q_Body,
                SubCaseBody=emergencyDto.SubCaseBody,
                Q_Id=emergencyDto.Q_Id,
                 SubCaseID= emergencyDto.SubCaseID,
                 User=emergencyDto.User,
                 UserName=emergencyDto.UserName,
                 UserId=emergencyDto.UserId
                 

            };
            await _emergencyRepo.Create(emergency);
            return Ok(emergency);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EmergencyDto emergencyDto)
        {
            var emergence = await _emergencyRepo.GetById(id);
            if (emergence == null)
                return NotFound($"Return Not found  Emergency with id ={id}");
            emergence.Address = emergencyDto.Address;
            emergence.CaseID = emergencyDto.CaseID;
            emergence.CH_Body = emergencyDto.CH_Body;
            emergence.CH_Id = emergencyDto.CH_Id;
            emergence.Q_Body = emergencyDto.Q_Body;
            emergence.SubCaseBody = emergencyDto.SubCaseBody;
            emergence.Q_Id = emergencyDto.Q_Id;
            emergence.SubCaseID = emergencyDto.SubCaseID;
            emergence.User = emergencyDto.User;
            emergence.UserName = emergencyDto.UserName;
            emergence.UserId = emergencyDto.UserId;

            _emergencyRepo.Update(emergence);
            return Ok(emergence);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emergency= await _emergencyRepo.GetById(id);
            if (emergency == null)
                return NotFound($"Return Not found  Emergency with id ={id}");
            _emergencyRepo.Delete(emergency);
            return Ok(emergency);
        }
    }
}
