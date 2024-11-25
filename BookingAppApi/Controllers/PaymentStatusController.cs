using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatusController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public PaymentStatusController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPaymentStatus() {
            var list = _context.paymentStatuses.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult CreatePaymentStatus(PaymentStatusModel statusModel )
        {
           PaymentStatus paymentStatus = new PaymentStatus()
           {
               PaymentStatusID = Guid.NewGuid(),
               PaymentStatusName = statusModel.Status
           };
            _context.paymentStatuses.Add(paymentStatus);
            _context.SaveChanges();
            return Ok(paymentStatus);
        }
    }
}
