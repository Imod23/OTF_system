using Microsoft.EntityFrameworkCore;
using OTF_System.Data;
using OTF_System.Models;
using OTF_System.Services;
using OTF_System.Data;
using OTF_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OTF_System.Services
{
    public class PoliceOfficerService : IPoliceOfficerService
    {
        private readonly dbcontext _context;

        public PoliceOfficerService(dbcontext context)
        {
            _context = context;
        }

        public async Task<List<PoliceOfficer>> GetAllOfficersAsync()
        {
            return await _context.PoliceOfficer.ToListAsync();
        }

        public async Task<PoliceOfficer> GetOfficerByIdAsync(string id)
        {
            return await _context.PoliceOfficer.FindAsync(id);
        }

        public async Task AddOfficerAsync(PoliceOfficer officer)
        {
            _context.PoliceOfficer.Add(officer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOfficerAsync(PoliceOfficer officer)
        {
            _context.PoliceOfficer.Update(officer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteOfficerAsync(string id)
        {
            var officer = await _context.PoliceOfficer.FindAsync(id);
            if (officer == null) return false;

            _context.PoliceOfficer.Remove(officer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
