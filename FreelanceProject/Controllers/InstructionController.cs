using FreelanceProject.API.Util;
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.Instructions;
using FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        private readonly IinstructionRepo _instructionRepo;
        private readonly ISubCaseRepo _SubRepo;
        private readonly ImageFilters _imageFilters;
        public InstructionController(IinstructionRepo iinstructionRepo, IOptionsMonitor<ImageFilters> imageFilters , ISubCaseRepo subCase)
        {
            _instructionRepo = iinstructionRepo;
            _imageFilters = imageFilters.CurrentValue;
            _SubRepo = subCase;
        }
        [HttpGet]
        [Route("{SubCaseID:int}")]
        public ActionResult<List<InstructionDtoRead>> GetAll(int SubCaseID)
        {


            var query = _instructionRepo.GetAll(SubCaseID);
                if(query.Count() > 0)
            {
                return query.Select(ins => new InstructionDtoRead
                {
                    HasImage = ins.HasImage,
                    ImageURL = ins.ImageURL,
                    Instruction_ID = ins.Ins_ID,
                    Ins_Body = ins.Ins_Body,
                    Order = ins.Order,
                    Severity = ins.Severity,
                    SubCases = ins.SubCases!.Select(sub => new InstructionSubcase { SubCase_ID = sub.Subcase_ID, SubCase_Title = sub.Subcase!.Title }).ToList()



                }).ToList();
            }
         
                return NotFound(new GeneralResponse("No Such instrcutions"));
            
            

            
        }

        [HttpGet]
        [Route("InsID/{id:int}")]
        public ActionResult<InstructionDtoRead> Get(int id)
        {
            var inst = _instructionRepo.Get(id);
            if(inst== null) { return NotFound(new GeneralResponse("No Such Instruction Exists")); }
            InstructionDtoRead newIns = new()
             {
                 HasImage = inst.HasImage,
                 ImageURL = inst.ImageURL,
                 Instruction_ID = inst.Ins_ID,
                 Ins_Body = inst.Ins_Body,
                 Order = inst.Order,
                 Severity = inst.Severity,
                 SubCases = inst.SubCases!.Select(sub => new InstructionSubcase { SubCase_ID = sub.Subcase_ID, SubCase_Title = sub.Subcase!.Title }).ToList()



             };
            return Ok(newIns);
        }

        [HttpPut]
        [Route("{Id:int}")]

        public ActionResult Edit([FromForm] InstructionDtoEdit ins , int Id  )
        {
            var newIns = _instructionRepo.Get(Id);
            if(newIns == null) { return NotFound(new GeneralResponse("No Such Instruction")); }



            newIns.Order = ins.Order ?? newIns.Order;
            newIns.Severity = ins.Severity ?? newIns.Severity;
            newIns.Ins_Body = ins.Ins_Body ?? newIns.Ins_Body;
            if (ins.Image is not null)
            {
                if (ins.Image.Length > _imageFilters.MaxSize)
                {
                    return BadRequest("the size is over the maximum size");
                }
                var sentExtension = Path.GetExtension(ins.Image.FileName).ToLower();
                if (_imageFilters.AllowedExtensions.Contains(sentExtension))
                {
                    var newName = $"{Guid.NewGuid()}{sentExtension}";
                    string FullPath = Directory.GetCurrentDirectory() + "\\wwwroot\\" + newName;

                    using (var stream = System.IO.File.Create(FullPath))
                    {
                        ins.Image.CopyTo(stream);
                    }
                    newIns.ImageURL = newName;
                    newIns.HasImage = true;
                }
            }
            else
            {
                newIns.HasImage = false;
            }

            _instructionRepo.Save();
            return Ok(new GeneralResponse("Record Updated Successfully"));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var insturction = _instructionRepo.Get(id);
            if (insturction == null) { return NotFound(new GeneralResponse("No Such Instruction")); }

            _instructionRepo.Delete(insturction);
            _instructionRepo.Save();
            return Ok(new GeneralResponse("Record Deleted Successfully"));
        }


        [HttpPost]
   
        public ActionResult Create([FromForm]InstructionDtoCreate ins)
        {
            Instructions newIns = new Instructions();
            
            newIns.Order = ins.Order;
            newIns.Severity = ins.Severity;
            newIns.Ins_Body = ins.Ins_Body;
            if(ins.Image is not null)
            {
                if(ins.Image.Length > _imageFilters.MaxSize) {
                    return BadRequest("the size is over the maximum size");
                }
                var sentExtension = Path.GetExtension(ins.Image.FileName).ToLower();
                if(_imageFilters.AllowedExtensions.Contains(sentExtension))
                {
                    var newName = $"{Guid.NewGuid()}{sentExtension}";
                    string FullPath = Directory.GetCurrentDirectory() + "\\wwwroot\\" + newName;

                    using(var stream = System.IO.File.Create(FullPath))
                    {
                        ins.Image.CopyTo(stream);
                    }
                    newIns.ImageURL = newName;
                    newIns.HasImage = true;
                }
            }
            else
            {
                newIns.HasImage = false;
            }

            int id = _instructionRepo.Create(newIns, ins.SubCase_ID);
            return CreatedAtAction(routeValues: new { id }, value: "Record added successfully", actionName: nameof(Get));
            
        }
    }
}
