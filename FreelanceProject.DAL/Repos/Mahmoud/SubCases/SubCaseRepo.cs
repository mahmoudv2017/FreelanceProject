



namespace FreelanceProject.DAL.Repos.Mahmoud.SubCases;

using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Models.Mahmoud;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class SubCaseRepo : ISubCaseRepo
{
    private readonly MedicalContext _context;

    public SubCaseRepo(MedicalContext context)
    {
        _context = context;
    }

    public int Create(SubCases SubCase)
    {
        var entity = _context.SubCases.Add(SubCase);
        Save();

        return entity.Entity.SubCaseID;
    }

    public void Delete(SubCases SubCase)
    {
        _context.SubCases.Remove(SubCase);
    }

    public SubCases? Get(int id)
    {
        return _context.SubCases.Where(sub => sub.SubCaseID == id)
            .Include(sub => sub.Case).Include(sub => sub.YoutubeLinks)
            .Include(sub => sub.Conditons)
            .Include(sub => sub.Instructions)
                .ThenInclude(ins => ins.Instruction)
            .FirstOrDefault(sub => sub.SubCaseID == id);
    }

    public List<SubCases> GetAll(int Case_ID)
    {
        //handle the project of YT Links
        //handle the projection of cases
        return _context.SubCases.Where(sub=>sub.CaseID==Case_ID).Include(sub => sub.Case).Include(sub => sub.Conditons!).Include(sub => sub.YoutubeLinks).Include(sub=>sub.Instructions!).ThenInclude(ins => ins.Instruction).ToList();
    }

    public void Save()
    {
       _context.SaveChanges();
    }
}
