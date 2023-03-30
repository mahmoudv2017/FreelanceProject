



namespace FreelanceProject.DAL.Repos.Mahmoud.Instructions;
using FreelanceProject.DAL.Models.Mahmoud;

public interface IinstructionRepo
{
    public List<Instructions> GetAll(int SubCaseID);

    public Instructions? Get(int id);

    void Save();
    public void Delete(Instructions Case);

    public int Create(Instructions Case , int SubCase_ID);
}
