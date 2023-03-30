

namespace FreelanceProject.DAL.Dtos;

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


