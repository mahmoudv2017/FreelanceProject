using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mona;
using FreelanceProject.DAL.Repos.Mona.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var users=await _userRepo.GetAll();
            return Ok(users);

        }
        [HttpGet("{id}")]
        public async Task< ActionResult<User>>GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            if(user == null)
            {
                return NotFound($"No User With Id {id}");
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task< ActionResult> Create(UserDto userDto)
        {
            var user = new User() { Email=userDto.Email,Name=userDto.Name,Password=userDto.Password};
           await _userRepo.Create(user);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] UserDto userDto)
        {
            var user =await _userRepo.GetById(id);
            if(user == null)
                return NotFound($"Return Not found  User with id ={id}");
            user.Email = userDto.Email;
            user.Name = userDto.Name;
            user.Password = userDto.Password;
            _userRepo.Update(user);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepo.GetById(id);
            if(user == null)
                return NotFound($"Return Not found  User with id ={id}");
            _userRepo.Delete(user);
            return Ok(user);
        }
    }
}
