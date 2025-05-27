using System.Collections.Generic;
using System.Threading.Tasks;
using OTF_System.Models;

namespace OTF_System.Services
{
    public interface IFineService
    {
        Task<List<Fine>> GetAllFinesAsync();
        Task<Fine> GetFineByIdAsync(string id);
        Task AddFineAsync(Fine fine);
        Task UpdateFineAsync(Fine fine);
        Task<bool> DeleteFineAsync(string id);
    }
}
