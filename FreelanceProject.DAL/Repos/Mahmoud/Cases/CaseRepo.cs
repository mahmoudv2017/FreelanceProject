
using FreelanceProject.DAL.Context;


namespace FreelanceProject.DAL.Repos.Mahmoud.Cases;
using FreelanceProject.DAL.Models.Mahmoud;
public class CaseRepo : ICasesRepo
{
    private readonly MedicalContext _MedicalContext;
    public CaseRepo(MedicalContext medicalContext)
    {
        _MedicalContext= medicalContext;
    }

    public int Create(Cases Case)
    {
        var _Case = _MedicalContext.Add(Case);
        _MedicalContext.SaveChanges();
       return _Case.Entity.CaseID;
    }

    public void Delete(Cases Case)
    {
         _MedicalContext.Cases.Remove(Case);
    }

    public Cases? Get(int id)
    {
        return  _MedicalContext.Cases.FirstOrDefault(c => c.CaseID == id );

    }

    public List<Cases> GetAll()
    {
        return _MedicalContext.Cases.ToList();
    }

    public void Save()
    {
        _MedicalContext.SaveChanges();
    }
}
