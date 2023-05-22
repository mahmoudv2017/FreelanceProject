using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mahmoud;

public class EmergencyV2
{
    public int ID { get; set; }
    public string CaseTitle { get; set; }=string.Empty;


    public string? SubCaseTitle { get; set; }

    public ICollection<Questions_Answers>? Questions_Answers { get; set; }


}
