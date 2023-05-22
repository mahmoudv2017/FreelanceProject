using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Dtos
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
       // ICollection<Emergency>? Emergencys { get; set; } = new HashSet<Emergency>();
    }
}
