using FreelanceProject.API.Util;
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.Conditions;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionsController : ControllerBase
    {
        private readonly IConditionRepo _conditionRepo;
        public ConditionsController(IConditionRepo conditionRepo) {
            _conditionRepo = conditionRepo;
        }
        [HttpGet]
        public List<ConditionDtoRead> GetAll(int? SubID)
        {
            if (SubID.HasValue)
            {
                return _conditionRepo.GetBySubCase(SubID.Value).Select(con => new ConditionDtoRead {Condition_ID=con.C_ID,
                C_Body=con.C_Body,
                SubCase_ID=con.SubCase_ID
                }).ToList();
            }
            return _conditionRepo.GetAll().Select(con => new ConditionDtoRead
            {
                Condition_ID = con.C_ID,
                C_Body = con.C_Body,
                SubCase_ID = con.SubCase_ID
            }).ToList();

        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Get(int id)
        {
            var condition = _conditionRepo.Get(id);
            if (condition == null) { return BadRequest(new GeneralResponse("No Such Conditon Exists")); }
            return Ok(new ConditionDtoRead { Condition_ID=condition.C_ID , C_Body=condition.C_Body , SubCase_ID=condition.SubCase_ID});

        }

        //[HttpGet]
        //[Route("")]
        //public ActionResult<List<Conditions>> GetBySubCaseID(int id) {

        //    return _conditionRepo.GetBySubCase(id);

        //}

        [HttpPut]
        [Route("{ConditionId:int}")]
        public ActionResult<Conditions> Edit(int ConditionId , [FromBody] ConditionDto cds)
        {
            cds.C_Body = cds.C_Body == "" ? null : cds.C_Body; 
            var EditedConditon = _conditionRepo.Get(ConditionId);
            if (EditedConditon == null) { return NotFound(new GeneralResponse("No Such Conditon Exists")); }
            EditedConditon.C_Body =   cds.C_Body ?? EditedConditon.C_Body;
         //   EditedConditon.SubCase_ID = cds.SubCase_ID ?? EditedConditon.SubCase_ID;

            _conditionRepo.Save();
            
            return Ok(EditedConditon);

        }

        [HttpPost]
        public ActionResult<Conditions> Create( [FromBody] ConditionDtoCreate cds)
        {
            var id = _conditionRepo.Create((Conditions)cds);

            return CreatedAtAction(actionName:nameof(Get) , routeValues:new { id } , value:"Condition Added Successfully");

        }


        [HttpDelete]
        [Route("{ConditionId:int}")]
        public ActionResult<Conditions> Remove(int ConditionId)
        {
            var condition = _conditionRepo.Get(ConditionId);
            if (condition == null) { return BadRequest(new GeneralResponse("No Such Conditon Exists")); }
            
            _conditionRepo.Delete(condition);

            return Ok(new GeneralResponse("Record Deleted Successfully"));

        }
    }
}
