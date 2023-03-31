using FreelanceProject.API.Util;
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;
using FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCasesController : ControllerBase
    {
        private readonly ISubCaseRepo _subCaseRepo;
        private readonly ICasesRepo _CaseRepo;
        public SubCasesController(ISubCaseRepo subCaseRepo , ICasesRepo casesRepo)
        {
            _subCaseRepo= subCaseRepo;
            _CaseRepo= casesRepo;
        }
        [HttpGet]
        [Route("{CaseID:int}")]
        public ActionResult<List<SubCaseDtoRead>> GetAll(int CaseID) {
            var query = _subCaseRepo.GetAll(CaseID).Select(sub => new SubCaseDtoRead
            {
                CaseID = sub.CaseID,
                CaseTitle= sub.Case!.Title ,
                SubCase_Title=sub.Title,
                SubCaseID=sub.SubCaseID,
                Instructions = sub.Instructions?.Select(ins => new SubCaseInstruction
                {
                    HasImage=ins.Instruction!.HasImage,
                    ImageURL=ins.Instruction.ImageURL,
                    Ins_Body=ins.Instruction.Ins_Body,
                    Instruction_ID=ins.Instructions_ID,
                    Order=ins.Instruction.Order,
                    Severity=ins.Instruction.Severity,
                }).OrderBy(ins => ins.Order).ToList(),
                Conditions = sub.Conditons?.Select(cond => new SubCaseCondtitions { Condition_ID = cond.C_ID , Condition_Body=cond.C_Body  }).ToList(),
                YTLinks =sub.YoutubeLinks.Select(yt => yt.Link).ToList(),
               
                
                
            }).ToList();

            return Ok(query);
        }

        [HttpGet]
        [Route("subID/{SubID:int}")]
        public ActionResult<SubCaseDtoRead> Get(int SubID)
        {
            var sub = _subCaseRepo.Get(SubID);
            if(sub is null) { return NotFound("No Such SubCase Exists"); }

            var query = new SubCaseDtoRead
            {
                CaseID = sub.CaseID,
                CaseTitle = sub.Case!.Title,
                SubCase_Title = sub.Title,
                SubCaseID = sub.SubCaseID,
                Instructions = sub.Instructions?.Select(ins => new SubCaseInstruction
                {
                    HasImage = ins.Instruction!.HasImage,
                    ImageURL = ins.Instruction.ImageURL,
                    Ins_Body = ins.Instruction.Ins_Body,
                    Instruction_ID = ins.Instructions_ID,
                    Order = ins.Instruction.Order,
                    Severity = ins.Instruction.Severity,
                }).OrderBy(ins => ins.Order).ToList(),
                Conditions = sub.Conditons?.Select(cond => new SubCaseCondtitions { Condition_ID = cond.C_ID, Condition_Body = cond.C_Body }).ToList(),
                YTLinks = sub.YoutubeLinks.Select(yt => yt.Link).ToList(),



            };
            return Ok(query);
        }

        [HttpDelete]
        [Route("subID/{SubID:int}")]
        public ActionResult<SubCases> Delete(int SubID)
        {
            var sub = _subCaseRepo.Get(SubID);
            if (sub is null) { return NotFound("No Such SubCase Exists"); }
            _subCaseRepo.Delete(sub);
            _subCaseRepo.Save();
            return Ok(new GeneralResponse("SubCase Deleted"));
        }

        [HttpPut]
        [Route("subID/{SubID:int}")]
        public ActionResult<SubCases> Edit(int SubID , SubCaseDto editor)
        {
            var sub = _subCaseRepo.Get(SubID);
            if (sub is null) { return NotFound("No Such SubCase Exists"); }
            
            sub.Title = editor.Title == "" ? sub.Title : editor.Title;
            sub.YoutubeLinks = editor.YTLinks?.Select(link => new SubCasesYoutubeLinks { Link = link, SubCaseID = SubID }).ToList() ?? sub.YoutubeLinks;
            _subCaseRepo.Save();

            return Ok(new GeneralResponse("Record Updated Successfully"));
        }

        [HttpPost]
        [Route("{CaseID:int}")]
        public ActionResult<SubCases> Create(int CaseID, SubCaseDto editor)
        {

            SubCases newSubcase = new SubCases { CaseID = CaseID, Title = editor.Title };

           var SubID = _subCaseRepo.Create(newSubcase);

            if(editor.YTLinks?.Count > 0)
            {
                newSubcase.YoutubeLinks = editor.YTLinks.Select(link => new SubCasesYoutubeLinks { Link = link, SubCaseID = SubID }).ToList();

            }
            //_subCaseRepo.Create();
            //if (sub is null) { return NotFound("No Such SubCase Exists"); }
            //sub.Title = editor.Title ?? sub.Title;

            _subCaseRepo.Save();

            return CreatedAtAction(routeValues:new { SubID } , value:"Record Created Successfully" , actionName:nameof(Get));
        }


    }
}
