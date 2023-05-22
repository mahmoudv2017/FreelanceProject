using FreelanceProject.DAL.Context;

using Microsoft.EntityFrameworkCore;


namespace FreelanceProject.DAL.Repos.Mahmoud.EmergencyV2;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;
using System.Threading.Tasks;

public class EmmergencyV2Repo : IEmergencyV2
{
    private readonly MedicalContext _context;
    public EmmergencyV2Repo(MedicalContext context)
    {
        _context= context;
    }
    public void Add(User_Emergency ev2)
    {
        _context.User_Emergency.Add(ev2) ;
        Save();
    }



    public List<User_Emergency> GetAll()
    {
        return _context.User_Emergency.Include(ue=>ue.User_Emergencies)!.ThenInclude(ue=>ue.Questions_Answers).Include(ue=>ue.User).ToList();
    }


    public void ChangeStatusBy(ApplicationUser user , Status status , User_Emergency _case)
    {
        var foundUser = _context.Emergency_Status_Changes.FirstOrDefault(en => en.UserID == user.Id && en.User_EmergencyID == _case.Id);
        if (foundUser is not null)
        {
            foundUser.StatusPart = status;
        }
        else
        {
            _case.Status_Changes!.Add(new Emergency_Status_Change { UserPart = user, Emergency_Part = _case, StatusPart = status });
        }

    }


    public User_Emergency? GetByID(int id)
    {
        return _context.User_Emergency.Include(ue => ue.User_Emergencies)!.ThenInclude(ue => ue.Questions_Answers).Include(en => en.ApprovedByUser).Include(ue => ue.User).FirstOrDefault(ex => ex.Id == id);
    }

    public List<User_Emergency>? GetByUserID(string id)
    {
        return _context.User_Emergency.Include(ue => ue.User_Emergencies)!.ThenInclude(ue => ue.Questions_Answers).Include(ue => ue.User).Where(ex => ex.User!.Id == id).ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Remove(User_Emergency ue)
    {
        _context.User_Emergency.Remove(ue);
        _context.SaveChanges();
    }

    public List<Emergency_Status_Change> GetUserVisibility(string userID)
    {
      return  _context.Emergency_Status_Changes.Where(en => en.UserID == userID ).ToList();
    }
}
