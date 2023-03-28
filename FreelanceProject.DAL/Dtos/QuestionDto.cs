using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Dtos
{
    public class QuestionDto
    {
        public string Body { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        ICollection<Cases> Cases { get; set; } = new HashSet<Cases>();
        ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
    }
}
