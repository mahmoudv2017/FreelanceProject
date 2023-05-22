using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mahmoud;

public class User_Emergency
{
    public int Id { get; set; }

    public string Address { get; set; }=string.Empty;

    public int UserID { get; set; }

    public User? User { get; set; }

   public ICollection<EmergencyV2>? User_Emergencies { get; set; }

}
