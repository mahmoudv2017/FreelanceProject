using FreelanceProject.DAL.Dtos;
using FreelanceProject.DAL.Models.Mona;
using FreelanceProject.DAL.Repos.Mona.Choices;
using FreelanceProject.DAL.Repos.Mona.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly IChoiceRepo _choiceRepo;
        public ChoiceController(IQuestionRepo questionRepo, IChoiceRepo choiceRepo)
        {
            _questionRepo = questionRepo;
            _choiceRepo = choiceRepo;
        }
        private readonly List<string> _allowedExtention = new List<string> { ".jpg", ".png" };
        private readonly long _maxAllowedImagesize = 1048576;

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ChoicesDto choicesDto)
        {
            if (choicesDto == null)
            {
                return BadRequest("Image Is required");
            }
            if (!_allowedExtention.Contains(Path.GetExtension(choicesDto.Image.FileName).ToLower()))
                return BadRequest("Only Allowed .png .jpg");
            if (choicesDto.Image.Length > _maxAllowedImagesize)
            {
                return BadRequest("Max Alled Size more than 1 m");
            }
            var isValid = await _questionRepo.IsValid(choicesDto.Q_Id);
            if (!isValid)
                return BadRequest("Invalid Question Id");
            using var dataStream = new MemoryStream();

            await choicesDto.Image.CopyToAsync(dataStream);

            var choice = new Choice();
            choice.Q_Id = choicesDto.Q_Id;
            choice.Body = choicesDto.Body;
            choice.ImageURL = choicesDto.ImageURL;
            choice.Image = dataStream.ToArray();

            _choiceRepo.Add(choice);
            return Ok(choice);


        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var choices = await _choiceRepo.GetAll();
            return Ok(choices);
        }
        [HttpGet("GetByQuestionId")]
        public async Task<IActionResult> GetByQuestionId(int id)
        {
            var Choices = await _choiceRepo.GetAll(id);
            return Ok(Choices);


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var choice = await _choiceRepo.GetById(id);
            if (choice == null)
            {
                return NotFound($"Not Found Choice with id {id}");
            }
            var dto = new Choice
            {
                Ch_ID = choice.Ch_ID,
                Q_Id = choice.Q_Id,
                Body = choice.Body,
                ImageURL = choice.ImageURL,
                Image = choice.Image,
                IsImage = choice.IsImage

            };
            return Ok(dto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var choice = await _choiceRepo.GetById(id);
            if (choice == null)
            {
                return NotFound($"No Choice was found with id {id}");
            }
            _choiceRepo.Delete(choice);
            return Ok(choice);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] ChoicesDto choicesDto)
        {
            var choice = await _choiceRepo.GetById(id);
            if (choice == null)
            {
                return NotFound($"No Choice was found with id {id}");
            }
            var isValid = await _questionRepo.IsValid(choicesDto.Q_Id);
            if (!isValid)
                return BadRequest("Invalid Question Id");
            if (choicesDto.Image != null)
            {
                if (!_allowedExtention.Contains(Path.GetExtension(choicesDto.Image.FileName).ToLower()))
                    return BadRequest("Only Allowed .png .jpg");
                if (choicesDto.Image.Length > _maxAllowedImagesize)
                {
                    return BadRequest("Max Alled Size more than 1 m");
                }
                using var dataStream = new MemoryStream();

                await choicesDto.Image.CopyToAsync(dataStream);
               choice.Image = dataStream.ToArray();
            }
           choice.ImageURL = choicesDto.ImageURL;
            choice.IsImage = choicesDto.IsImage;
            choice.Q_Id = choicesDto.Q_Id;
            choice.Body = choicesDto.Body;
            _choiceRepo.Update(choice);
            return Ok(choice);
        }
    }
}