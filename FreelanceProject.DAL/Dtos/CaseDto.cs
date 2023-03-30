
using FreelanceProject.DAL.Models.Mahmoud;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FreelanceProject.DAL.Dtos;

public class EditCaseDto
{


    public bool? HasConditions { get; set; }

    public string? Title { get; set; } = string.Empty;
    //public string ImageUrl { get; set; } = string.Empty;

    public IFormFile? image { get; set; }

  //add casting later
}

public class CreateCaseDto
{


    public bool HasConditions { get; set; }

    public string Title { get; set; } = string.Empty;
    //public string ImageUrl { get; set; } = string.Empty;

    public IFormFile? image { get; set; }

    //add casting later
}
