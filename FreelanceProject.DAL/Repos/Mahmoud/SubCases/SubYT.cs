using FreelanceProject.DAL.Context;

namespace FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using FreelanceProject.DAL.Models.Mahmoud;

public class SubYT : ISubYTLinks
{
    private readonly MedicalContext _context;
    public SubYT(MedicalContext context) { _context = context; }
    public void AddLink(SubCases sub, string link)
    {
        sub.YoutubeLinks.Add(new SubCasesYoutubeLinks { Link= link  , SubCaseID=sub.SubCaseID});
        _context.SaveChanges();
    }

    public void RemoveLink(SubCases sub, SubCasesYoutubeLinks link)
    {
        sub.YoutubeLinks.Remove(link);
        _context.SaveChanges();
    }

    public List<SubCasesYoutubeLinks> YoutubeLinks(SubCases sub)
    {
        return sub.YoutubeLinks.ToList();
    }

  

   
}
