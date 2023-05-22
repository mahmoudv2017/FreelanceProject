

namespace FreelanceProject.DAL.Models.Mahmoud;

public class Questions_Answers
{
    public int Id { get; set; }


   
    public string CastTitle { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;

    

    public ICollection<EmergencyV2>? Emergencies { get; set; }
}
