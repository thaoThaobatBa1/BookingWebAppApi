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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly BookingDbContext _context;

        public CustomerController(ICustomerService customerService, BookingDbContext context)
        {
            _customerService = customerService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerModel customermodel)
        {
            if (customermodel == null)
            {
                return BadRequest();
            }

          
            var customer = new Customer()
            {
                CustomerID = new Guid(),
               Name = customermodel.Name,
               PhoneNumber = customermodel.PhoneNumber
            };
            await _customerService.AddAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.CustomerID }, customer);
        }
        [HttpPost("WithUser")]
        public async Task<IActionResult> CreateWithUser([FromBody] CustomerModelWithUser customermodel)
        {
            if (customermodel == null)
            {
                return BadRequest();
            }
            var exitCustomerWithUser = _context.Customers.FirstOrDefault(a => a.UserId == customermodel.UserId);

            if (exitCustomerWithUser == null)
            {
                var customer = new Customer()
                {
                    CustomerID = new Guid(),
                    Name = customermodel.Name,
                    PhoneNumber = customermodel.PhoneNumber,
                    UserId = customermodel.UserId
                };
                await _customerService.AddAsync(customer);
                return CreatedAtAction(nameof(GetById), new { id = customer.CustomerID }, customer);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = exitCustomerWithUser.CustomerID }, exitCustomerWithUser);
            }
        }
        [HttpGet("withUser{id}")]
        public async Task<IActionResult> GetByUSerId(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(a => a.UserId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }
            await _customerService.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
