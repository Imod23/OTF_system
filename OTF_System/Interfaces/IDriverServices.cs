using System.Collections.Generic;
using System.Threading.Tasks;
using OTF_System.Models;
using OTF_System.Models;

namespace OTF_System.Services
{
    public interface IDriverService
    {
        Task<List<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByLicenceNoAsync(string licenceNo);
        Task AddDriverAsync(Driver driver);
        Task UpdateDriverAsync(Driver driver);
        Task<bool> DeleteDriverAsync(string licenceNo);
    }
}
