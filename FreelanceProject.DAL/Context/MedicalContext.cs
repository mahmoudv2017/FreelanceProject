using FreelanceProject.DAL.Models.Mahmoud;
using Microsoft.EntityFrameworkCore;


namespace FreelanceProject.DAL.Context;

public class MedicalContext:DbContext
{
    #region Mahmoud
    public DbSet<Cases> Cases => Set<Cases>();
    public DbSet<Instructions> Instructions => Set<Instructions>();

    public DbSet<SubCasesYoutubeLinks> SubCasesYoutubeLinks=> Set<SubCasesYoutubeLinks>();
    public DbSet<SubCases> SubCases => Set<SubCases>();
    public DbSet<Conditions> Conditions => Set<Conditions>();

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
