using Azure;
using FreelanceProject.API.Util;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase 
    {
        private readonly ILogger<CasesController> _logger;
        private readonly ICasesRepo _casesRepo;

        public CasesController(ILogger<CasesController> logger, ICasesRepo casesRepo)
        {
            _logger = logger;
            _casesRepo = casesRepo;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var Case = _casesRepo.Get(id);
            if (Case == null) { return NotFound(new GeneralResponse("No Such Cases Exists" )); }
            _casesRepo.Delete(Case);
            _casesRepo.Save();
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Cases> GetByID(int id)
        {
            var Case = _casesRepo.Get(id);
            if(Case is null) { return NotFound(new GeneralResponse("No Such Cases Exists")); }
            return Case;
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<Cases> Edit(Cases _Case , int id)
        {
            var Case = _casesRepo.Get(id);
            if (Case is null) { return NotFound(new GeneralResponse("No Such Cases Exists")); }

            Case.Title = _Case.Title;
            Case.HasConditions = _Case.HasConditions;
            Case.ImageUrl = _Case.ImageUrl;

            _casesRepo.Save();

         
            return Ok(new GeneralResponse("Record Updated Successfully"));
        }

        [HttpGet]

        public List<Cases> GetAll()
        {
           return _casesRepo.GetAll();
        }

        [HttpPost]
        public ActionResult Create(Cases Case)
        {
            var id = _casesRepo.Create(Case);

            return CreatedAtAction(actionName: nameof(GetByID), routeValues: new { id = id }, value: new GeneralResponse("Record is added successfully"));
        }



    }
}
