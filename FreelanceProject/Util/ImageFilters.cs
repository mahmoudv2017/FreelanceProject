using FreelanceProject.DAL.Models.Mahmoud;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceProject.API.Util;


public class ImageFilters
{
    public int MaxSize { get; set; }
    public List<string> AllowedExtensions { get; set; }=new List<string>();

    //public ActionResult CheckMyImage(IFormFile img , ImageFilters _filters)
    //{
    //    if (img.Length > _filters.MaxSize) { return BadRequest(new GeneralResponse($"{Case.image.FileName} is bigger then 2MB")); }
    //    var ImageExtension = Path.GetExtension(Case.image.FileName);

    //    if (!_filters.AllowedExtensions.Contains(ImageExtension.ToLower())) { return BadRequest(new GeneralResponse("Unsupported Extension")); }
    //}
}
