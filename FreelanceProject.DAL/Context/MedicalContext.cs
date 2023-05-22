using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace FreelanceProject.DAL.Context;

public class MedicalContext : IdentityDbContext<ApplicationUser>
{
    #region Mahmoud
    //public DbSet<Cases> Cases => Set<Cases>();
    //public DbSet<Instructions> Instructions => Set<Instructions>();
    //public DbSet<Subcase_Instructions> SubCases_Instructions => Set<Subcase_Instructions>();
    //public DbSet<SubCasesYoutubeLinks> SubCasesYoutubeLinks => Set<SubCasesYoutubeLinks>();
    //public DbSet<SubCases> SubCases => Set<SubCases>();
    //public DbSet<Conditions> Conditions => Set<Conditions>();






    public DbSet<Emergency_Status_Change> Emergency_Status_Changes=> Set<Emergency_Status_Change>();
    public DbSet<EmergencyV2> EmergencyV2 => Set<EmergencyV2>();
    public DbSet<User_Emergency> User_Emergency => Set<User_Emergency>();
    public DbSet<Questions_Answers> Questions_Answers => Set<Questions_Answers>();

    #endregion

    #region Mona
    //public DbSet<Question> Questions => Set<Question>();
    //public DbSet<Choice> Choices => Set<Choice>();
    //public DbSet<Question_Case> Question_Cases => Set<Question_Case>();
    //public DbSet<Emergency> Emergencies => Set<Emergency>();
    #endregion
    public MedicalContext(DbContextOptions<MedicalContext> options) : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  

     
        


        modelBuilder.Entity<User_Emergency>().Property(e => e.Latitude).HasColumnType("decimal(8,6)");
        modelBuilder.Entity<User_Emergency>().Property(e => e.Logntitue).HasColumnType("decimal(9,6)");

        modelBuilder.Entity<User_Emergency>(con =>
        {
            con.HasOne(en => en.ApprovedByUser)
            .WithMany(en => en.ApprovedEmergencies)
            .HasForeignKey(en => en.ApprovedBy);
        });

        modelBuilder.Entity<Emergency_Status_Change>(config =>
        {
            config.HasKey(en => new { en.UserID, en.User_EmergencyID });

            config.HasOne(en => en.UserPart)
            .WithMany(en => en.Status_Changes)
            .HasForeignKey(en => en.UserID);

            config.HasOne(en => en.Emergency_Part)
            .WithMany(en => en.Status_Changes)
            .HasForeignKey(en => en.User_EmergencyID);

        });

        base.OnModelCreating(modelBuilder);
    }
}
