using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mona
{
   public class Choice
    {
        [Key]
        public int Ch_ID { get; set; }
        public bool IsImage { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public string Body{ get; set; } = string.Empty;
        [ForeignKey("Question")]
        public int Q_Id { get; set; }
        public Question ?Question { get; set; } 
    }
}
