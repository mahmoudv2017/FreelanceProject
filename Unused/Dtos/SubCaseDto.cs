

using FreelanceProject.DAL.Models.Mahmoud;

namespace FreelanceProject.DAL.Dtos;


/*
 {
    "subCaseID": 1,
    "caseID": 1,
    "case": null,
    "title": " ST احتشاء عضلة القلب الناجم عن ارتفاع مقطع",
    "youtubeLinks": [],
    "instructions": [
      {
        "instructions_ID": 1,
        "subcase_ID": 1,
        "instruction": {
          "ins_ID": 1,
          "order": 1,
          "severity": 2,
          "ins_Body": "اتصل على  رقم الطوارئ في بلدك",
          "hasImage": true,
          "imageURL": "aef31cc0-63c1-40fe-b969-53df54a74ebc.png",
          "subCases": []
        }
      },
      {
        "instructions_ID": 2,
        "subcase_ID": 1,
        "instruction": {
          "ins_ID": 2,
          "order": 2,
          "severity": 0,
          "ins_Body": "امضغ الأسبرين ثم ابلعه أثناء انتظارك المساعدة الطارئة.",
          "hasImage": false,
          "imageURL": null,
          "subCases": []
        }
      },
      {
        "instructions_ID": 6,
        "subcase_ID": 1,
        "instruction": {
          "ins_ID": 6,
          "order": 4,
          "severity": 2,
          "ins_Body": "njhgjh",
          "hasImage": true,
          "imageURL": "569796ad-9a36-4455-9669-4aa779098f16.png",
          "subCases": []
        }
      },
      {
        "instructions_ID": 7,
        "subcase_ID": 1,
        "instruction": {
          "ins_ID": 7,
          "order": 6,
          "severity": 1,
          "ins_Body": "werfsdffgdgdfgdfgdfg",
          "hasImage": true,
          "imageURL": "c24930d5-ecaf-4754-b0f2-5084d1fbc6f2.png",
          "subCases": []
        }
      },
      {
        "instructions_ID": 8,
        "subcase_ID": 1,
        "instruction": {
          "ins_ID": 8,
          "order": 9,
          "severity": 2,
          "ins_Body": "bcvbcvbcvb",
          "hasImage": true,
          "imageURL": "700af89a-475f-47de-9a77-6769b2bdacab.png",
          "subCases": []
        }
      }
    ],
    "conditons": [
      {
        "c_ID": 1,
        "subCase_ID": 1,
        "c_Body": "انزعاج أو شعور بالألم في منطقة الصدر"
      },
      {
        "c_ID": 2,
        "subCase_ID": 1,
        "c_Body": "string"
      },
      {
        "c_ID": 3,
        "subCase_ID": 1,
        "c_Body": "  ألم المعدة و ضيق تنفس "
      }
    ]
  }
 */

public class SubCaseInstruction
{
    public int Instruction_ID { get; set; }
    public int Order { get; set; }

    public Severity Severity { get; set; }

    public string Ins_Body { get; set; } = string.Empty;

    public bool HasImage { get; set; }
    public string? ImageURL { get; set; }
}

public class SubCaseCondtitions
{
    public int Condition_ID { get; set; }
    public string Condition_Body { get; set; }=string.Empty;
}
public class SubCaseDtoRead
{
   

    public int SubCaseID { get; set; }
    public int CaseID { get; set; }
    public string CaseTitle { get; set; } = string.Empty;
    public string SubCase_Title { get; set; }=string.Empty;
    //youtube links
    public List<string>? YTLinks { get; set; }

    public List<SubCaseCondtitions>? Conditions { get; set; }

    public List<SubCaseInstruction>? Instructions { get; set; }
}
public class SubCaseDto
{
   


    //public int CaseID { get; set; }
    //adding conditions

    public string Title { get; set; } = string.Empty;

    //youtube links
    public List<string>? YTLinks { get; set; }
}

public class SubCaseDtoEdit
{

    public string? Title { set; get; }

   // public int CaseID { get; set; }


    

    //youtube links
  //  public List<string>? YTLinks { get; set; }
}


