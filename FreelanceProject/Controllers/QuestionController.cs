using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mona;
using FreelanceProject.DAL.Repos.Mona.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionController(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }
        [HttpPost]
        public async Task<ActionResult> Create(QuestionDto questionDto)
        {
            var question = new Question() { Type = questionDto.Type, Body = questionDto.Body };
            await _questionRepo.Create(question);
            return Ok(question);
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var question = await _questionRepo.GetAll();
            return Ok(question);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetById(int id)
        {
            var question = await _questionRepo.GetById(id);
            if(question == null) 
            {
                return NotFound();
            }
            else
            {
                return Ok(question);
            }
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Edit(int id, [FromBody]QuestionDto questionDTO)
        {
            var context=await _questionRepo.GetById(id);
            if(context == null)
            {
                return NotFound($"Return Not found  genere with id ={id}");
            }
            context.Body=questionDTO.Body;
            context.Type=questionDTO.Type;
            _questionRepo.Update(context);
            return Ok(context); 
        }
        [HttpDelete("{id}")]
    public async Task< IActionResult> Delete(int id)
        {
            var context = await _questionRepo.GetById(id);
            if( context == null)
            {
                return NotFound($"Return Not found  genere with id ={id}");
            }
            _questionRepo.Delete(context);
            return Ok(context);
        }
    }
}
