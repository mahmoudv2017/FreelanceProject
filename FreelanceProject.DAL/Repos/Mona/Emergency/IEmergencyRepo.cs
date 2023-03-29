using FreelanceProject.DAL.Models.Mona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Emergency
{
    public interface IEmergencyRepo
    {
        Task<IEnumerable<Emergencys>> GetAll();
        Task<Emergencys> GetById(int id);
        Task<Emergencys> Create(Emergencys emergencys);
        Emergencys Update(Emergencys emergencys);
        Emergencys Delete(Emergencys emergencys);
        Task<bool> IsValid(int id);
    }
}
