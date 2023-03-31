using FreelanceProject.DAL.Models.Mahmoud;

using Microsoft.AspNetCore.Http;

namespace FreelanceProject.DAL.Dtos;

/*
  {
    "ins_ID": 1,
    "order": 1,
    "severity": 2,
    "ins_Body": "اتصل على  رقم الطوارئ في بلدك",
    "hasImage": false,
    "imageURL": null,
    "subCases": [
      {
    
        "subcase_ID": 1,
        "subcase_body": "
      }
    ]
  }
 */

public class InstructionSubcase
{
    public int SubCase_ID { get; set; }
    public string SubCase_Title { get; set;}=string.Empty;
}
public class InstructionDtoRead
{

    public int Instruction_ID { get; set; }
    public int Order { get; set; }

    public Severity Severity { get; set; }

    public string Ins_Body { get; set; } = string.Empty;

    public bool HasImage { get; set; }
    public string? ImageURL { get; set; }


    public List<InstructionSubcase>? SubCases { get; set; }

}
public class InstructionDtoCreate
{


    public int Order { get; set; }

    public Severity Severity { get; set; }

    public string Ins_Body { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }

    public int SubCase_ID { get; set; }

}

public class InstructionDtoEdit
{


    public int? Order { get; set; }

    public Severity? Severity { get; set; }

    public bool? HasImage { get; set; }
    public string? Ins_Body { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }

   // public int SubCase_ID { get; set; }

}
