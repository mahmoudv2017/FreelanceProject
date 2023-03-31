using FreelanceProject.DAL.Models.Mahmoud;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;


namespace FreelanceProject.DAL.Context;

public class MedicalContext : DbContext
{
    #region Mahmoud
    public DbSet<Cases> Cases => Set<Cases>();
    public DbSet<Instructions> Instructions => Set<Instructions>();
    public DbSet<Subcase_Instructions> SubCases_Instructions => Set<Subcase_Instructions>();
    public DbSet<SubCasesYoutubeLinks> SubCasesYoutubeLinks => Set<SubCasesYoutubeLinks>();
    public DbSet<SubCases> SubCases => Set<SubCases>();
    public DbSet<Conditions> Conditions => Set<Conditions>();

    #endregion

    #region Mona
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Choice> Choices => Set<Choice>();
    public DbSet<Question_Case> Question_Cases => Set<Question_Case>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Emergency> Emergencies => Set<Emergency>();
    #endregion
    public MedicalContext(DbContextOptions<MedicalContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region seeding

        var cases = new List<Cases> {
            new Cases { CaseID=1, HasConditions=false , Title="ازمة قلبية" , ImageUrl ="heart.jpg"},
            new Cases {CaseID=2, HasConditions=false , Title="الاغماء" , ImageUrl="faints.png"},
            new Cases {CaseID=3, HasConditions=false , Title="العضات",ImageUrl="bites.jpg"},
            new Cases {CaseID=4, HasConditions=false , Title="اللدغات",ImageUrl="antsBite.png"},

        };

        var subcases = new List<SubCases> {

            //For Case 1
            new SubCases { CaseID=1, SubCaseID=1 , Title="ST احتشاء عضلة القلب الناجم عن ارتفاع مقطع" },
            new SubCases { CaseID=1, SubCaseID=2 , Title="النوبات القلبية الصامتة"},
            new SubCases { CaseID=1, SubCaseID=3 , Title="ST احتشاء عضلة القلب غير المرتبطة بمقطع"},


             //For Case 2
            new SubCases { CaseID=2, SubCaseID=4 , Title="(إغماء وعائي مبهمي (إغماء قلبي وعصبي" },
            new SubCases { CaseID=2, SubCaseID=5 , Title="إغماء الظرفية"},
            new SubCases { CaseID=2, SubCaseID=6 , Title="(الإغماء الوضعي (انخفاض ضغط الدم الوضعي"},
            new SubCases { CaseID=2, SubCaseID=7 , Title="إغماء عصبي"},
            new SubCases { CaseID=2, SubCaseID=8 , Title="(POTS) متلازمة تسرع القلب الانتصابي الوضعي "},



             //For Case 3
            new SubCases { CaseID=3, SubCaseID=9 , Title="عضات سامة" },
            new SubCases { CaseID=3, SubCaseID=10 , Title="عضات غير سامة"},
        

            //For Case 4
            new SubCases { CaseID=4, SubCaseID=11 , Title="قرصة القراد" },
            new SubCases { CaseID=4, SubCaseID=12 , Title="قرصة العنكبوت"},
            new SubCases { CaseID=4, SubCaseID=13 , Title="قرصة البعوض"},
            new SubCases { CaseID=4, SubCaseID=14 , Title="قرصات بق الفراش"},
            new SubCases { CaseID=4, SubCaseID=15 , Title="قرصات قمل الرأس"},
            new SubCases { CaseID=4, SubCaseID=16 , Title="لدغات البراغيث"},
        };

        var Conditions = new List<Conditions> {
            new Conditions { C_ID=1, C_Body="انزعاج أو شعور بالألم في منطقة الصدر",SubCase_ID=1},
             new Conditions { C_ID=2, SubCase_ID=1 , C_Body="الألم في الجزء العلوي من الجسم"},
            new Conditions { C_ID=3, SubCase_ID=1 , C_Body="  ألم المعدة و ضيق تنفس "},
        };

        var Instructions = new List<Instructions> {
            new Instructions { HasImage=false , Ins_Body="اتصل على  رقم الطوارئ في بلدك",Ins_ID=1,Order=1,Severity=Severity.info },
            new Instructions { HasImage=false , Ins_Body="امضغ الأسبرين ثم ابلعه أثناء انتظارك المساعدة الطارئة.",Ins_ID=2,Order=2,Severity=Severity.danger },
           new Instructions { HasImage=false , Ins_Body="تناول نيتروغلسرين، إذا وُصف لك",Ins_ID=3,Order=3,Severity=Severity.info },
            new Instructions { HasImage=false , Ins_Body=" ابدأ الإنعاش القلبي الرئوي إذا كان الشخص فاقدًا للوعي.",Ins_ID=4,Order=4,Severity=Severity.info },

        };

        modelBuilder.Entity<Cases>().HasData(cases);
        modelBuilder.Entity<SubCases>().HasData(subcases);
        modelBuilder.Entity<Conditions>().HasData(Conditions);
        modelBuilder.Entity<Instructions>().HasData(Instructions);

        modelBuilder.Entity<Subcase_Instructions>().HasData(
            new List<Subcase_Instructions>(){
                new Subcase_Instructions { Instructions_ID=1 , Subcase_ID=1},
             new Subcase_Instructions { Instructions_ID=2 , Subcase_ID=1},
             new Subcase_Instructions { Instructions_ID=3 , Subcase_ID=1},
             }
        );
        #endregion

        modelBuilder.Entity<Subcase_Instructions>(config =>
        {
            config.HasKey(ins => new { ins.Subcase_ID, ins.Instructions_ID });

            config.HasOne(ins => ins.Subcase)
            .WithMany(ins => ins.Instructions)
            .HasForeignKey(ins => ins.Subcase_ID);

            config.HasOne(ins => ins.Instruction)
            .WithMany(ins => ins.SubCases)
            .HasForeignKey(ins => ins.Instructions_ID);

        });

        modelBuilder.Entity<SubCasesYoutubeLinks>().HasKey(en => new { en.SubCaseID, en.Link });

        base.OnModelCreating(modelBuilder);
    }
}
