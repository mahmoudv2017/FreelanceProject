using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mona
{
    public class Emergency
    {
        [Key]
        public int Id { get; set; }
        public int CaseID { get; set; }
        public int SubCaseID { get; set; }
        public string SubCaseBody { get; set; }
        public int Q_Id { get; set; }
        public string Q_Body { get; set; }
        public string CH_Body { get; set; }
        public int CH_Id { get; set;}
        public string Address{ get; set;}
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public User? User { get; set; }

    }
}
