using FreelanceProject.DAL.Models.Mahmoud;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mona
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName{ get; set; } = string.Empty; 
        //public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public ICollection<User_Emergency>? ApprovedEmergencies { get; set; }
        public ICollection<Emergency_Status_Change>? Status_Changes { get; set; }
    }
}
