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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly BookingDbContext _context;

        public BookingController(IBookingService bookingService, BookingDbContext context)
        {
            _bookingService = bookingService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingModel bookingMD)
        {
            if (bookingMD == null)
            {
                return BadRequest();
            }


            var booking = new Booking()
            {
                BookingID = new Guid(),
                NumberOfGuests = bookingMD.NumberOfGuests,
                BookingDate = DateTime.Now,
                ReservationTime = DateTime.Now.TimeOfDay,
                CustomerID = bookingMD.CustomerId,
                OrderID = bookingMD.OderId,
                Price = _context.Tables.FirstOrDefault(a => a.TableID == bookingMD.TableId).Price
            };



            await _bookingService.AddAsync(booking);
            var bookingtable = new BookingTable()
            {
                BookingID = booking.BookingID,
                TableID = bookingMD.TableId
            };
            _context.BookingTables.Add(bookingtable);
            _context.SaveChanges();
            _context.Orders.FirstOrDefault(a => a.OrderID == booking.OrderID).TotalPrice += booking.Price;
            _context.SaveChanges();
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return BadRequest();
            }
            await _bookingService.UpdateAsync(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
