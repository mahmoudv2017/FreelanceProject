using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Questions
{
    public interface IQuestionRepo
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question>GetById(int id);
        Task<Question>Create(Question question);
        Question Update(Question question);
        Question Delete(Question question);
        Task<bool>IsValid(int id);

    }
}
