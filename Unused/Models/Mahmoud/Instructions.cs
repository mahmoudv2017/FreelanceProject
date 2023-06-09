﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceProject.DAL.Models.Mahmoud;


public enum Severity
{
    danger, warning, info
}

public class Instructions
{
    [Key]
    public int Ins_ID { get; set; }

    public int Order { get; set; }

    public Severity Severity { get; set; }

    public string Ins_Body { get; set; } = string.Empty;

    public bool HasImage { get; set; }
    public string? ImageURL { get; set; }

    public ICollection<Subcase_Instructions>? SubCases { get; set; }

}
