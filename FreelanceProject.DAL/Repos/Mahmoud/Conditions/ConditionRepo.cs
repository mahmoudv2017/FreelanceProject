

namespace FreelanceProject.DAL.Repos.Mahmoud.Conditions;

using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mahmoud;

public class ConditionRepo : IConditionRepo
{
    private readonly MedicalContext _context;

    public ConditionRepo(MedicalContext medicalContext)
    {
        _context= medicalContext;
    }
    public int Create(Conditions Condition)
    {
        var AddedEntity = _context.Conditions.Add(Condition);
        Save();

        return AddedEntity.Entity.C_ID;
    }

    public void Delete(Conditions Condition)
    {
        _context.Conditions.Remove(Condition);
        Save();
    }

    public Conditions? Get(int id)
    {
      return  _context.Conditions.FirstOrDefault(con => con.C_ID == id);
    }

    public List<Conditions> GetAll()
    {
        return _context.Conditions.ToList();
    }

    public List<Conditions> GetBySubCase(int sub_id)
    {
        return _context.Conditions.Where(con => con.SubCase_ID == sub_id).ToList();
    }

 

    public void Save()
    {
        _context.SaveChanges();
    }
}
