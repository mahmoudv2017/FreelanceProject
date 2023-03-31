

using FreelanceProject.DAL.Models.Mahmoud;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceProject.DAL.Dtos;

public class ConditionDto
{

    //public int? SubCase_ID { get; set; }

    public string? C_Body { get; set; } = string.Empty;

}


public class ConditionDtoRead
{
    public int Condition_ID { get; set; }
    public int SubCase_ID { get; set; }

    public string C_Body { get; set; } = string.Empty;

  

}

public class ConditionDtoCreate
{

  
 
    public int SubCase_ID { get; set; }

    public string C_Body { get; set; } = string.Empty;

    public static explicit operator Conditions(ConditionDtoCreate cds)
    {
        return new Conditions() { C_Body=cds.C_Body , SubCase_ID=cds.SubCase_ID};
    } 

}
