using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Repos.Mahmoud.Cases;

using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]

        public ActionResult<List<Cases>> GetAll()
        {
           return _casesRepo.GetAll();
        }
    }
}
