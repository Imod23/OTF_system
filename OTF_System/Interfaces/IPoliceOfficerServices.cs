using OTF_System.Models;
using OTF_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OTF_System.Services
{
    public interface IPoliceOfficerService
    {
        Task<List<PoliceOfficer>> GetAllOfficersAsync();
        Task<PoliceOfficer> GetOfficerByIdAsync(string id);
        Task AddOfficerAsync(PoliceOfficer officer);
        Task UpdateOfficerAsync(PoliceOfficer officer);
        Task<bool> DeleteOfficerAsync(string id);
    }
}
