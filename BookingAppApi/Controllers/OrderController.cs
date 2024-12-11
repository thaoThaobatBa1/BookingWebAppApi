using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private BookingDbContext _context;

        public OrderController(IOrderService orderService, BookingDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }
       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var order = new Order()
            {
                OrderID = new Guid(),
                OrderDate = DateTime.Now,
                TotalPrice = 0,
                PaymentStatusId = Guid.Parse( "01222858-5ea5-42fc-b041-86618591df46")
            };

            await _orderService.AddAsync(order);
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }
            await _orderService.UpdateAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }
    }
}
