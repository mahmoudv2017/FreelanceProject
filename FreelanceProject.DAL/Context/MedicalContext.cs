using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FreelanceProject.DAL.Context;

public class MedicalContext : IdentityDbContext<ApplicationUser>
{
    #region Mahmoud
    public DbSet<Cases> Cases => Set<Cases>();
    public DbSet<Instructions> Instructions => Set<Instructions>();

    public DbSet<SubCasesYoutubeLinks> SubCasesYoutubeLinks=> Set<SubCasesYoutubeLinks>();
    public DbSet<SubCases> SubCases => Set<SubCases>();
    public DbSet<Conditions> Conditions => Set<Conditions>();

    #endregion

    #region Mona
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Choice> Choices => Set<Choice>();
    public DbSet<Question_Case>Question_Cases => Set<Question_Case>();
   // public DbSet<User> Users => Set<User>(); 
    public DbSet<Emergencys>Emergencies => Set<Emergencys>();
    #endregion
    public MedicalContext(DbContextOptions<MedicalContext> options):base(options)   
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region seeding
        #endregion


        base.OnModelCreating(modelBuilder);
    }
}
