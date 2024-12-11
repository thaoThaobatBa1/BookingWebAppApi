using BookingShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.ISeivces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(Guid id);
        Task AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(Guid id);
    }
}
