using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Models.Mona
{
    public class AuthModel
    {
        public string? UserID { get; set; }
        public string Message { get; set; }=string.Empty;
        public bool IsAuthentication { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string>Roles { get; set; } = new List<string>();
        public string Token { get;set; } = string.Empty;
        public DateTime Expireson { get; set; }
    }
}
