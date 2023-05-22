using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mahmoud;



public class User_Emergency
{
    public int Id { get; set; }

    public string CreatedAt { get; set; } = string.Empty;
    public decimal Logntitue { get; set; }

    public decimal Latitude { get; set; }
    public string? ApplicationUserID { get; set; }


  

    public Status Status { get; set; }



    public string? ApprovedBy { get; set; }
    public ApplicationUser? ApprovedByUser { get; set; }
    public ICollection<Emergency_Status_Change> Status_Changes { get; set; }=new List<Emergency_Status_Change>();

    public ApplicationUser? User { get; set; }

   public ICollection<EmergencyV2>? User_Emergencies { get; set; }

}
