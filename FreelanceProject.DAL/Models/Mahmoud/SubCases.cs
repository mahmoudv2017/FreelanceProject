

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceProject.DAL.Models.Mahmoud;

public class SubCases
{
    [Key]
    public int SubCaseID { get; set; }

    [ForeignKey("Cases")]
    public int CaseID { get; set; }
    public Cases? Case { get; set; }

    public string Title { get; set; } = string.Empty;

    //youtube multivalued
    public ICollection<SubCasesYoutubeLinks> YoutubeLinks { get; set; } = new HashSet<SubCasesYoutubeLinks>();
    public ICollection<Instructions> Instructions { get; set; } = new HashSet<Instructions>();
}
