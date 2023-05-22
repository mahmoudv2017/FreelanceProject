

namespace FreelanceProject.DAL.Models.Mahmoud;

public class Subcase_Instructions
{
    public int Instructions_ID { get; set; }
    public int Subcase_ID { get; set; }

    public Instructions? Instruction { get; set; }

    public SubCases? Subcase { get; set; }


}
