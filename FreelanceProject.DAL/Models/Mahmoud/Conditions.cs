
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FreelanceProject.DAL.Models.Mahmoud;

public class Conditions
{
    [Key]
    public int C_ID { get; set; }

    [ForeignKey("SubCases")]
    public int SubCase_ID { get; set; }

    public string C_Body { get; set; }=string.Empty;

    public SubCases? SubCases { get; set; }

}
