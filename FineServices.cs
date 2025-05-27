using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OTF_System.Models;
using OTF_System.Data;
using OTF_System.Data;
using OTF_System.Services;

namespace Sachintha.Services
{
    public class FineService : IFineService
    {
        private readonly dbcontext _context;

        public FineService(dbcontext context)
        {
            _context = context;
        }

        public async Task<List<Fine>> GetAllFinesAsync()
        {
            return await _context.Fine.ToListAsync();
        }

        public async Task<Fine> GetFineByIdAsync(string id)
        {
            return await _context.Fine.FindAsync(id);
        }

        public async Task AddFineAsync(Fine fine)
        {
            _context.Fine.Add(fine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFineAsync(Fine fine)
        {
            _context.Fine.Update(fine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteFineAsync(string id)
        {
            var fine = await _context.Fine.FindAsync(id);
            if (fine == null) return false;

            _context.Fine.Remove(fine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
