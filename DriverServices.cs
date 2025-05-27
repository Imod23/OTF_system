using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OTF_System.Models;
using OTF_System.Data;
using OTF_System.Models;

namespace OTF_System.Services
{
    public class DriverService : IDriverService
    {
        private readonly dbcontext _context;

        public DriverService(dbcontext context)
        {
            _context = context;
        }

        public async Task<List<Driver>> GetAllDriversAsync()
        {
            return await _context.Driver.ToListAsync();
        }

        public async Task<Driver> GetDriverByLicenceNoAsync(string licenceNo)
        {
            return await _context.Driver.FindAsync(licenceNo);
        }

        public async Task AddDriverAsync(Driver driver)
        {
            _context.Driver.Add(driver);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            _context.Driver.Update(driver);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDriverAsync(string licenceNo)
        {
            var driver = await _context.Driver.FindAsync(licenceNo);
            if (driver == null) return false;

            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
