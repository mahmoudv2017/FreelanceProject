

using FreelanceProject.DAL.Models.Mahmoud;
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

    public List<QandADto> Q_As { get; set; } = new List<QandADto>();
}

public class EmergencyStatus
{
    public string UserID { get; set; } = string.Empty;
    public Status newStatus { get; set; } 
}

public class ApprovedByUserDto
{
    public string? UserID { get; set; } 
    public string? Username { get; set; }
    public string? Email { get; set; }
}
public class EmergencyV2DTosRead
{
    public int id { get; set; }
    public string CreatedAt { get; set; }=string.Empty;
    public string UserID { get; set; }=string.Empty;
    public Status Status { get; set; }

    public string? ApprovedBy { get; set; }

    public ApprovedByUserDto? ApprovedByUser { get; set; }
    public string Username { get; set; }=string.Empty;
    //public int PhoneNumber { get; set; }
    public LocationDtio? Location { get; set; }
    public List<EmergencyDtoList>? Emergencies { get; set;}


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

public class LocationDtio
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

}

public class VisibilityDto
{
    public string UserID { get; set; } = string.Empty;

}

public class VisibilityDtoWithData
{
    public List<EmergencyV2DTosRead>? Data { get; set; } 
    public List<VisibilityDtoResult>? Visibility { get; set; }
}



public class VisibilityDtoResult
{
    public string UserID { get; set; } = string.Empty;
    public int E_ID { get; set; }
    public Status Status { get; set; }
}


public class EmergencyV2DTosCreate
{
    public string UserID { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    //public int PhoneNumber { get; set; }
    public string Address { get; set; } = string.Empty;
    public List<EmergencyDtoList> Emergencies { get; set; }=new List<EmergencyDtoList>();


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