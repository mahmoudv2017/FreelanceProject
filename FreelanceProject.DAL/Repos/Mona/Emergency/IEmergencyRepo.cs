

namespace FreelanceProject.DAL.Repos.Mona.Emergency;
using FreelanceProject.DAL.Models.Mona;

public interface IEmergencyRepo
{
    Task<IEnumerable<Emergency>> GetAll();
    Task<Emergency?> GetById(int id);
    Task<Emergency> Create(Emergency Emergency);
    Emergency Update(Emergency Emergency);
    Emergency Delete(Emergency Emergency);
    Task<bool> IsValid(int id);
}
