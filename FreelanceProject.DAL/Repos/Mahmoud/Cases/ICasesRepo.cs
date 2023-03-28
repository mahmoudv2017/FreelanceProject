



namespace FreelanceProject.DAL.Repos.Mahmoud.Cases;

using FreelanceProject.DAL.Models.Mahmoud;
public interface ICasesRepo
{
    public List<Cases> GetAll();

    public Cases? Get(int id);

    void Save();
    public void Delete(Cases Case);

    public int Create(Cases Case);
}
