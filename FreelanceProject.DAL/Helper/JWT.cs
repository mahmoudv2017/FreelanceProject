using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreelanceProject.DAL.Helper;

public class JWTc
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double DurationInDay { get; set; }
}
