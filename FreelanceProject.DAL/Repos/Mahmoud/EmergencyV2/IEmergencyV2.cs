
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mahmoud.EmergencyV2;
using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;

public interface IEmergencyV2
{
    void Add(User_Emergency ev2);
    public List<User_Emergency> GetAll();
    public User_Emergency? GetByID(int id);
    public void Remove(User_Emergency ue);
    public void ChangeStatusBy(ApplicationUser user, Status status, User_Emergency _case);
    public List<Emergency_Status_Change> GetUserVisibility(string userID); 
    public List<User_Emergency>? GetByUserID(string id);
    void Save();
}
