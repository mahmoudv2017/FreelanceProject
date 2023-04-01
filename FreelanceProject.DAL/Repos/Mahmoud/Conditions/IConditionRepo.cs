


namespace FreelanceProject.DAL.Repos.Mahmoud.Conditions;

using FreelanceProject.DAL.Models.Mahmoud;
public interface IConditionRepo
{
    public List<Conditions> GetAll();
    public List<Conditions> GetBySubCase(int sub_id);
    public Conditions? Get(int id);

    void Save();
    public void Delete(Conditions Case);

    public int Create(Conditions Case);
}
