using FreelanceProject.DAL.Context;


using FreelanceProject.DAL.Models.Mona;

using Microsoft.EntityFrameworkCore;


namespace FreelanceProject.DAL.Repos.Mona.Emergency;
using FreelanceProject.DAL.Models.Mona;

public class EmergencyRepo : IEmergencyRepo
{
    private readonly MedicalContext _medicalContext;

    public EmergencyRepo(MedicalContext medicalContext)
    {
        _medicalContext = medicalContext;
    }
    public async Task<Emergency> Create(Emergency Emergency)
    {
        await _medicalContext.Emergencies.AddAsync(Emergency);
        _medicalContext.SaveChanges();
        return Emergency;
    }

    public Emergency Delete(Emergency Emergency)
    {
        _medicalContext.Remove(Emergency);
        _medicalContext.SaveChanges();
        return Emergency;
    }

    public  async Task<IEnumerable<Emergency>> GetAll()
    {
        return await _medicalContext.Emergencies.OrderBy(u => u.User).ToListAsync();
    }

    public async Task<Emergency?> GetById(int id)
    {
        return await _medicalContext.Emergencies.SingleOrDefaultAsync(u => u.Id == id);
    }

    public Task<bool> IsValid(int id)
    {
        return _medicalContext.Emergencies.AnyAsync(u => u.Id == id);
    }

    public Emergency Update(Emergency Emergency)
    {
        _medicalContext.Update(Emergency);
        _medicalContext.SaveChanges();
        return Emergency;
    }
}
