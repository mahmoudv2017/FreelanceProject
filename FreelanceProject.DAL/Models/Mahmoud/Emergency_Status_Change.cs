using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mahmoud;

public class Emergency_Status_Change
{
    public string UserID { get; set; }=string.Empty;
    public ApplicationUser? UserPart { get; set; }

    public int User_EmergencyID { get; set; }
    public User_Emergency? Emergency_Part { get; set; }

    public Status StatusPart { get; set; }

}
