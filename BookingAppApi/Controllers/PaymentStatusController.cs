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
    [HttpGet("UpdateStatus")]
    public IActionResult UpdatePaymentStatus(Guid id)
    {
       var cureentOrder = _context.Orders.FirstOrDefault(a => a.OrderID == id) ;
      cureentOrder.PaymentStatusId = Guid.Parse("18cce18d-a516-4155-89b2-51eed783951d");
      _context.SaveChanges();
      return Ok(cureentOrder);

    }


  }
}
