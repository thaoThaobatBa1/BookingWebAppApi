using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTableController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingTableController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostBookingTable(BookingTableModel1 bookingTableModel)
        {
            BookingTable bookingTable = new BookingTable()
            {
                BookingID = bookingTableModel.BookingId,
                TableID = bookingTableModel.TableId,
                BookingTableId = Guid.NewGuid() 
            };

            _context.BookingTables.Add(bookingTable);

            var bookingAtTable = _context.Bookings.FirstOrDefault(a => a.BookingID == bookingTable.BookingID);

            if (bookingAtTable == null)
            {
                return BadRequest(new { message = "Booking not found." });
            }
            _context.SaveChanges();

            var tableAtBooking = _context.BookingTables
               .Where(a => a.BookingID == bookingAtTable.BookingID)
               .Select(bt => bt.TableID)
               .Distinct()
               .ToList();

            decimal price = 0;
            foreach (var tableId in tableAtBooking)
            {
                var table = _context.Tables.FirstOrDefault(a => a.TableID == tableId);
                if (table != null)
                {
                    price += table.Price;
                }
            }

            bookingAtTable.Price = price;

            _context.SaveChanges();

            return Ok(new { mes = bookingTable, priceChange = price });
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_context.BookingTables.ToList());
        }
    }
}
