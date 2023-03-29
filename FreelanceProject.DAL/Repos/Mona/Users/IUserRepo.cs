using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Users
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User user);
        User Update(User user);
        User  Delete(User user);
        Task<bool> IsValid(int id);
    }
}
