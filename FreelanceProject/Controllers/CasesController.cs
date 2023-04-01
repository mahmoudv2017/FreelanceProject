using Azure;
using FreelanceProject.API.Util;
using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;


namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase 
    {
        private readonly ILogger<CasesController> _logger;
        private readonly ImageFilters _filters;
        private readonly ICasesRepo _casesRepo;

        public CasesController(ILogger<CasesController> logger, ICasesRepo casesRepo, IOptionsMonitor<ImageFilters> imagefilter )
        {
            _logger = logger;
            _casesRepo = casesRepo;
            _filters = imagefilter.CurrentValue;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var Case = _casesRepo.Get(id);
            if (Case == null) { return NotFound(new GeneralResponse("No Such Cases Exists" )); }
            _casesRepo.Delete(Case);
            _casesRepo.Save();
            return Ok(new GeneralResponse("Record Deleted Successfully"));
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ReadCaseDto> GetByID(int id)
        {
            var Case = _casesRepo.Get(id);
            if(Case is null) { return NotFound(new GeneralResponse("No Such Cases Exists")); }

            var newCase = new ReadCaseDto { CaseID= Case.CaseID , ImageUrl=Case.ImageUrl , Title=Case.Title};
            return newCase;
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<Cases> Edit( [FromForm] EditCaseDto _Case , int id)
        {
            var Case = _casesRepo.Get(id);
            if (Case is null) { return NotFound(new GeneralResponse("No Such Cases Exists")); }

            Case.Title = _Case.Title ?? Case.Title;
            //Case.HasConditions = _Case.HasConditions ?? Case.HasConditions;
            
            if(_Case.image is not null)
            {
                if (_Case.image.Length > _filters.MaxSize) { return BadRequest(new GeneralResponse($"{_Case.image.FileName} is bigger then 2MB")); }

                var ImageExtension = Path.GetExtension(_Case.image.FileName);

                if (!_filters.AllowedExtensions.Contains(ImageExtension.ToLower())) { return BadRequest(new GeneralResponse("Unsupported Extension")); }

                string NewName = $"{Guid.NewGuid()}{ImageExtension}";
                string FullPath = Directory.GetCurrentDirectory() + "\\wwwroot\\" + NewName;

                using (var stream = System.IO.File.Create(FullPath.Trim()))
                {
                    _Case.image.CopyTo(stream);
                }
                Case.ImageUrl = NewName;

            }
          


            _casesRepo.Save();

         
            return Ok(new GeneralResponse("Record Updated Successfully"));
        }

        [HttpGet]

        public ActionResult<List<ReadCaseDto>>  GetAll()
        {
           return  Ok(_casesRepo.GetAll().Select(Case => new ReadCaseDto { Title=Case.Title , ImageUrl=Case.ImageUrl , CaseID=Case.CaseID} ).ToList());
        }

        [HttpPost]
        public ActionResult Create([FromForm] CreateCaseDto Case)
        {

            if(Case.image is null) { return BadRequest(new GeneralResponse("Image is Reuqired")); }

            if(Case.image.Length > _filters.MaxSize) { return BadRequest(new GeneralResponse($"{Case.image.FileName} is bigger then 2MB")); }

            var ImageExtension = Path.GetExtension(Case.image.FileName);

            if (!_filters.AllowedExtensions.Contains(ImageExtension.ToLower())) { return BadRequest(new GeneralResponse("Unsupported Extension")); }

            string NewName = $"{Guid.NewGuid()}{ImageExtension}";
            string FullPath = Directory.GetCurrentDirectory()+"\\wwwroot\\" + NewName;

            using(var stream = System.IO.File.Create(FullPath.Trim()))
            {
               Case.image.CopyTo(stream);
            }



            Cases newCase = new Cases{ Title=Case.Title };
            newCase.ImageUrl = NewName;

            var id = _casesRepo.Create(newCase);

            return CreatedAtAction(actionName: nameof(GetByID), routeValues: new { id }, value: new GeneralResponse("Record is added successfully"));
        }



    }
}
