



namespace FreelanceProject.DAL.Repos.Mahmoud.SubCases;
using FreelanceProject.DAL.Models.Mahmoud;
public interface ISubYTLinks
{
    public List<SubCasesYoutubeLinks> YoutubeLinks(SubCases sub);
    public void AddLink(SubCases sub ,string link);
    public void RemoveLink(SubCases sub, SubCasesYoutubeLinks link);
 
}
