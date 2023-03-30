using FreelanceProject.API.Util;
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCasesController : ControllerBase
    {
        private readonly ISubCaseRepo _subCaseRepo;
        public SubCasesController(ISubCaseRepo subCaseRepo)
        {
            _subCaseRepo= subCaseRepo;
        }
        [HttpGet]
        [Route("{CaseID:int}")]
        public ActionResult<List<SubCases>> GetAll(int CaseID) {
            return _subCaseRepo.GetAll(CaseID);
        }

        [HttpGet]
        [Route("subID/{SubID:int}")]
        public ActionResult<SubCases> Get(int SubID)
        {
            var sub = _subCaseRepo.Get(SubID);
            if(sub is null) { return NotFound("No Such SubCase Exists"); }

            return Ok(sub);
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
            sub.Title = editor.Title ?? sub.Title;
            sub.YoutubeLinks = editor.YTLinks?.Select(link => new SubCasesYoutubeLinks { Link = link, SubCaseID = SubID }).ToList() ?? sub.YoutubeLinks;
            _subCaseRepo.Save();

            return Ok(sub);
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
