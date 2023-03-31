using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Users
{
    public class UserRepo : IUserRepo
    {
        private readonly MedicalContext _medicalContext;

        public UserRepo(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }

        public async Task<User> Create(User user)
        {
            await _medicalContext.Users.AddAsync(user);
            _medicalContext.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            _medicalContext.Remove(user);
            _medicalContext.SaveChanges();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _medicalContext.Users.OrderBy(u => u.Name).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _medicalContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public Task<bool> IsValid(int id)
        {
            return _medicalContext.Users.AnyAsync(u => u.Id == id);
        }

        public User Update(User user)
        {
            _medicalContext.Update(user);
            _medicalContext.SaveChanges();
            return user;
        }
    }
}
