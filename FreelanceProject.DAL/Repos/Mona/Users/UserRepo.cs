using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepo(MedicalContext medicalContext , UserManager<ApplicationUser> userManager )
        {
            _medicalContext = medicalContext;
            _userManager = userManager;
        }

        public Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }


        public List<ApplicationUser> GetAll()
        {
            return  _userManager.Users.ToList();  
        }

        public Task<ApplicationUser?>  GetById(string id)
        {
           return  _userManager.FindByIdAsync(id);
        }

        public ApplicationUser? GetByUsername(string username)
        {
           return _medicalContext.Users.FirstOrDefault(user => user.UserName!.ToLower() == username.ToLower());
        }

        public Task<bool> IsValid(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> Update(ApplicationUser user , string oldPassword , string newPassword)
        {
           return _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public void save()
        {
             _medicalContext.SaveChanges();
        }

        public void Delete(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        //public async Task<User> Create(User user)
        //{
        //    await _medicalContext.Users.AddAsync(user);
        //    _medicalContext.SaveChanges();
        //    return user;
        //}

        //public User Delete(User user)
        //{
        //    _medicalContext.Remove(user);
        //    _medicalContext.SaveChanges();
        //    return user;
        //}

        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    return await _medicalContext.Users.OrderBy(u => u.Name).ToListAsync();
        //}

        //public async Task<User> GetById(int id)
        //{
        //    return await _medicalContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        //}

        //public User? GetByUsername(string username)
        //{
        //    return _medicalContext.Users.SingleOrDefault(user => user.Name.ToLower() == username.ToLower());
        //}

        //public Task<bool> IsValid(int id)
        //{
        //    return _medicalContext.Users.AnyAsync(u => u.Id == id);
        //}

        //public User Update(User user)
        //{
        //    _medicalContext.Update(user);
        //    _medicalContext.SaveChanges();
        //    return user;
        //}
    }
}
