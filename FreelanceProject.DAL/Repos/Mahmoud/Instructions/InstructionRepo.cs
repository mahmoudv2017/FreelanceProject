



namespace FreelanceProject.DAL.Repos.Mahmoud.Instructions;

using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mahmoud;
using Microsoft.EntityFrameworkCore;

public class InstructionRepo : IinstructionRepo
{
    private readonly MedicalContext _context;

    public InstructionRepo(MedicalContext context)
    {
        _context = context;
    }

    public int Create(Instructions Ins , int SubCase_ID)
    {
        var entity = _context.Instructions.Add(Ins);
        Save();
        //adding a record to the SubCaseInstruction Joined Table
        _context.SubCases_Instructions.Add(new Subcase_Instructions() { Instructions_ID = entity.Entity.Ins_ID, Subcase_ID = SubCase_ID });

        Save();

        return entity.Entity.Ins_ID;
    }

    public void Delete(Instructions Case)
    {
        _context.Instructions.Remove(Case);

    }

    public Instructions? Get(int id)
    {
      return  _context.Instructions.Where(ins => ins.Ins_ID == id).Include(Ins => Ins.SubCases)!.ThenInclude(sub => sub.Subcase).FirstOrDefault(ins => ins.Ins_ID == id);
    }

    public List<Instructions> GetAll(int SubCaseID)
    {
        return _context.Instructions.Include(Ins => Ins.SubCases)!.ThenInclude(sub => sub.Subcase).AsEnumerable().Where(ins => ins.SubCases!.FirstOrDefault(sub => sub.Subcase_ID == SubCaseID) == null ? false : true).ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
