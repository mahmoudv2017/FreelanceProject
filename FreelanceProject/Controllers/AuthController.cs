using JWT.Services;
using Azure;
using FreelanceProject.API.Util;
using FreelanceProject.DAL.Models.Mahmoud;


using Microsoft.AspNetCore.Mvc;
using System.Net;
using FreelanceProject.DAL.Models.Mona;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }








        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthentication)
                return BadRequest(result.Message);
            return Ok(result);
        }








        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthentication)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.AddRoleAsync(model);

            if (string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(model);
        }
    }
}
