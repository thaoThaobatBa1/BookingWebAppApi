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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;

        public PaymentMethodService(IRepository<PaymentMethod> paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _paymentMethodRepository.GetAllAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodByIdAsync(Guid id)
        {
            return await _paymentMethodRepository.GetByIdAsync(id);
        }

        public async Task AddPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            await _paymentMethodRepository.AddAsync(paymentMethod);
        }

        public async Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }

        public async Task DeletePaymentMethodAsync(Guid id)
        {
            await _paymentMethodRepository.DeleteAsync(id);
        }
    }

}
