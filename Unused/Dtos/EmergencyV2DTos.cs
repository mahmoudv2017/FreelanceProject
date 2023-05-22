

using FreelanceProject.DAL.Models.Mona;

namespace FreelanceProject.DAL.Dtos;




public class QandADto
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;

    //   public string SubCaseTitle { get; set; }=string.Empty;  

}
public class EmergencyDtoList
{
    public string CaseTitle { get; set; } = string.Empty;
    //   public string SubCaseTitle { get; set; }=string.Empty;  

    public List<QandADto> Q_As { get; set; }
}

public class EmergencyV2DTosRead
{
    public int ID { get; set; }
    public string Username { get; set; }=string.Empty;
    //public int PhoneNumber { get; set; }
    public string Address { get; set; }= string.Empty;
    public List<EmergencyDtoList> Emergencies { get; set;}


//    username:string,
//  phoneNo:number,
//  address:string,
//  emergency : {
//    CaseTitle:string,
//    SubCaseTitle?:string,
//    Q&A:[
//      {
//        Questions:string,
//        Answer:string
//}
//    ]
//  }
}
