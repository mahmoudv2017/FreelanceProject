using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Dtos
{
    public class EmergencyDto
    {
        public int CaseID { get; set; }
        public int SubCaseID { get; set; }
        public string SubCaseBody { get; set; }
        public int Q_Id { get; set; }
        public string Q_Body { get; set; }
        public string CH_Body { get; set; }
        public int CH_Id { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public User? User { get; set; }

    }
}
