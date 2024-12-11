using BookingAppApi.Model;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;

    public PaymentMethodController(IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
        return Ok(paymentMethods);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentMethodById(Guid id)
    {
        var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
        if (paymentMethod == null)
        {
            return NotFound();
        }
        return Ok(paymentMethod);
    }

    [HttpPost]
    public async Task<IActionResult> AddPaymentMethod([FromBody] PaymentMenthodModel paymentMethodMD)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var id = new Guid();

        var paymentMethod = new PaymentMethod()
        {
            PaymentMethodID = id,
            MethodName = paymentMethodMD.MethodName
        };

        await _paymentMethodService.AddPaymentMethodAsync(paymentMethod);
        return CreatedAtAction(nameof(GetPaymentMethodById), new { id = paymentMethod.PaymentMethodID }, paymentMethod);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePaymentMethod(Guid id, [FromBody] PaymentMethod paymentMethod)
    {
        if (id != paymentMethod.PaymentMethodID)
        {
            return BadRequest();
        }

        await _paymentMethodService.UpdatePaymentMethodAsync(paymentMethod);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaymentMethod(Guid id)
    {
        await _paymentMethodService.DeletePaymentMethodAsync(id);
        return NoContent();
    }
}
