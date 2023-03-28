
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FreelanceProject.DAL.Models.Mahmoud;

public class SubCasesYoutubeLinks
{
    [Key]
    public int Id { get; set; }

    
    [ForeignKey("SubCases")]
    public int SubCaseID { get; set; }

    public string Link { get; set; }=string.Empty;

    public SubCases? SubCases { get; set; }
}
