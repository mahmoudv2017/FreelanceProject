using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Choices
{
    public interface IChoiceRepo
    {
        Task<IEnumerable<Choice>> GetAll(int questionId=0);
        Task<Choice> GetById(int id);
        Task<Choice>Add(Choice choice);
        Choice Update(Choice choice);
        Choice Delete(Choice choice);
    }
}
