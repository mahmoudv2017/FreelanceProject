using FreelanceProject.DAL.Context;
using FreelanceProject.DAL.Migrations;
using FreelanceProject.DAL.Models.Mona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceProject.DAL.Repos.Mona.Emergency
{
    public class EmergencyRepo : IEmergencyRepo
    {
        private readonly MedicalContext _medicalContext;

        public EmergencyRepo(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }
        public async Task<Emergencys> Create(Emergencys emergencys)
        {
            await _medicalContext.Emergencies.AddAsync(emergencys);
            _medicalContext.SaveChanges();
            return emergencys;
        }

        public Emergencys Delete(Emergencys emergencys)
        {
            _medicalContext.Remove(emergencys);
            _medicalContext.SaveChanges();
            return emergencys;
        }

        public  async Task<IEnumerable<Emergencys>> GetAll()
        {
            return await _medicalContext.Emergencies.OrderBy(u => u.User).ToListAsync();
        }

        public async Task<Emergencys> GetById(int id)
        {
            return await _medicalContext.Emergencies.SingleOrDefaultAsync(u => u.Id == id);
        }

        public Task<bool> IsValid(int id)
        {
            return _medicalContext.Emergencies.AnyAsync(u => u.Id == id);
        }

        public Emergencys Update(Emergencys emergencys)
        {
            _medicalContext.Update(emergencys);
            _medicalContext.SaveChanges();
            return emergencys;
        }
    }
}
