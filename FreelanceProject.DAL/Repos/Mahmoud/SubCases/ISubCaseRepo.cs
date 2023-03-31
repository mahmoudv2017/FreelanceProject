
namespace FreelanceProject.DAL.Repos.Mahmoud.SubCases;

using FreelanceProject.DAL.Models.Mahmoud;

public interface ISubCaseRepo
{
    public List<SubCases> GetAll(int CaseID);

    public SubCases? Get(int id);

    void Save();
    public void Delete(SubCases Case);

    public int Create(SubCases Case);
}
