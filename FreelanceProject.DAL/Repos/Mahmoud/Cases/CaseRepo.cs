
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
