using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Choices
{
    
    public class ChoiceRepo : IChoiceRepo
    {
        private readonly MedicalContext _medicalContext;

        public ChoiceRepo(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }

        public async Task<Choice> Add(Choice choice)
        {
            await _medicalContext.AddAsync(choice);
            _medicalContext.SaveChanges();
            return choice;
        }

        public Choice Delete(Choice choice)
        {
            _medicalContext.Remove(choice);
            _medicalContext.SaveChanges();
            return choice;
        }

        public async Task<IEnumerable<Choice>> GetAll(int questionId = 0)
        {
            return await _medicalContext.Choices.Where(m => m.Q_Id == questionId || questionId == 0).Include(c => c.Question).ToListAsync();
        }

        public async Task<Choice> GetById(int id)
        {
            return await _medicalContext.Choices.Include(c => c.Question).SingleOrDefaultAsync(c => c.Ch_ID == id);
        }

        public Choice Update(Choice choice)
        {
           _medicalContext.Update(choice);
            _medicalContext.SaveChanges();
            return choice;
        }
    }
}
