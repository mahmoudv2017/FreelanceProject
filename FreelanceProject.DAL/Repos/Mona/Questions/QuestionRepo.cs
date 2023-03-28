using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Questions
{
    public class QuestionRepo : IQuestionRepo
    {
        public readonly MedicalContext _MedicalContext;

        public QuestionRepo(MedicalContext medicalContext)
        {
            _MedicalContext = medicalContext;
        }

        public async Task<Question> Create(Question question)
        {
            await _MedicalContext.AddAsync(question);
            _MedicalContext.SaveChanges();
            return question;
        }

        public Question Delete(Question question)
        {
            _MedicalContext.Remove(question);
            _MedicalContext.SaveChanges();
            return question;
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _MedicalContext.Questions.Include(c=>c.Cases).Include(ch=>ch.Choices).OrderBy(t=>t.Type).ToListAsync();
        }

        public async Task<Question> GetById(int id)
        {
            return await _MedicalContext.Questions.SingleOrDefaultAsync(q=>q.Q_ID==id);
        }

        public async Task<bool> IsValid(int id)
        {
            return await _MedicalContext.Questions.AnyAsync(q => q.Q_ID == id);
        }

        public Question Update(Question question)
        {
            _MedicalContext.Update(question);
            _MedicalContext.SaveChanges();
            return question;
        }
    }
}
