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
    public class Question_Case
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int Q_ID { get; set; }
        [ForeignKey("Case")]
        public int Case_ID { get; set; }
        ICollection<Question> Questions { get; set;}=new HashSet<Question>();
        ICollection<Cases> Cases { get; set; } = new HashSet<Cases>();

    }
}
