
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FreelanceProject.DAL.Models.Mahmoud;

public class SubCasesYoutubeLinks
{
    
    
    [ForeignKey("SubCases")]
    public int SubCaseID { get; set; }


    public string Link { get; set; }=string.Empty;

    public SubCases? SubCases { get; set; }
}
