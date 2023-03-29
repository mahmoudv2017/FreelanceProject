using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FreelanceProject.DAL.Models.Mona;

namespace FreelanceProject.DAL.Dtos
{
    public class ChoicesDto
    {
        [Key]
        public int Ch_ID { get; set; }
        public bool IsImage { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public string Body { get; set; } = string.Empty;
        [ForeignKey("Question")]
        public int Q_Id { get; set; }
      
    }
}

