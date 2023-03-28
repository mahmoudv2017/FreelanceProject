using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FreelanceProject.DAL.Models.Mahmoud;

public class Cases
{
    [Key]
    public int CaseID { get; set; }

    public bool HasConditions { get; set; }

    public string Title { get; set; }=string.Empty;
    public string ImageUrl { get; set; }= string.Empty;

}
