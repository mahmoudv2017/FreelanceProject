using FreelanceProject.DAL.Models.Mona;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Users
{
    public interface IUserRepo
    {
        List<ApplicationUser> GetAll();
        Task<ApplicationUser?>  GetById(string id);
        Task<User> Create(User user);
        ApplicationUser? GetByUsername(string username);
        Task<IdentityResult> Update(ApplicationUser user, string oldPassword, string newPassword);
        void  Delete(ApplicationUser user);
        void save();
        Task<bool> IsValid(int id);
    }
}
