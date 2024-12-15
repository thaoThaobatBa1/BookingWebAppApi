using BookingAppApi.Model;
using BookingAppApi.Model.VnPay;
using BookingAppApi.VnPayService;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IVnPayService _vnPayService;

    public PaymentController(IPaymentService paymentService, IVnPayService vnPayService)
    {
      _paymentService = paymentService;
      _vnPayService = vnPayService;
    }
    [HttpPost("VnPay")]
    public IActionResult CreatePaymentUrlVnpay(PaymentInformationModel model)
    {
      var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
      return Ok(new { paymentUrl = url });
    }

    [HttpGet("VnPayCallback")]
    public IActionResult PaymentCallbackVnpay()
    {
      var response = _vnPayService.PaymentExecute(Request.Query);
      return Ok(response);
    }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(Guid id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult> AddPayment([FromBody] PaymentModel paymentMD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid id = Guid.NewGuid();

            var payment = new Payment()
            {
                PaymentID = id,
                Amount = paymentMD.Amount,
                PaymentDate = DateTime.Now,
                OrderID = paymentMD.OrderID,
                PaymentMethodID = paymentMD.PaymentMethodID,
            };

            await _paymentService.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentID }, payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayment(Guid id, [FromBody] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return BadRequest();
            }

            await _paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(Guid id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
