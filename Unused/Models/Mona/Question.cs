using FreelanceProject.DAL.Models.Mahmoud;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mona
{
    public class Question
    {
        [Key]
        public int Q_ID { get; set; }
        public string Body { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int CaseID { get; set; }
        public int ChoiceID { get; set; }
        //[ForeignKey(nameof(Cases))]
        public ICollection<Cases>? Cases { get; set; } = new HashSet<Cases>();
        //[ForeignKey(nameof(Choice))]
        public ICollection<Choice>? Choices { get; set; } = new HashSet<Choice>();

    }
}
