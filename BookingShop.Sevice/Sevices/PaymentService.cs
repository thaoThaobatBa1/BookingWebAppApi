using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Sevice.Sevices
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;

        public PaymentService(IRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(Guid id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
        }

        public async Task DeletePaymentAsync(Guid id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
