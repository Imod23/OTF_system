using System.Collections.Generic;
using System.Threading.Tasks;
using OTF_System.Models;
using OTF_System.Models;

namespace Sachintha.Services
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(string id);
        Task AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(string id);
    }
}
