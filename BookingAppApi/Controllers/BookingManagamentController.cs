using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingManagamentController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingManagamentController(BookingDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Bookingdata(BookingTableModel bookingdata)
        {
           Booking booking = new Booking()
           {
               BookingID = new Guid(),
               BookingDate = DateTime.Now,
           };

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllBookingInfo()
        {
            var bookingList = from booking in _context.Bookings
                              join order in _context.Orders on booking.OrderID equals order.OrderID
                              join customer in _context.Customers on booking.CustomerID equals customer.CustomerID
                              join bookingTable in _context.BookingTables on booking.BookingID equals bookingTable.BookingID
                              join table in _context.Tables on bookingTable.TableID equals table.TableID
                              join paymentStatus in _context.paymentStatuses on order.PaymentStatusId equals paymentStatus.PaymentStatusID
                              select new BookingListInformation()
                              {
                                  OrderID = order.OrderID,
                                  BookingDate = booking.BookingDate,
                                  Deposit = order.TotalPrice * 0.3m,
                                  NameOfGuest = customer.Name,
                                  NumberOfGuests = booking.NumberOfGuests,
                                  PhoneNumber = customer.PhoneNumber,
                                  ReservationTime = booking.ReservationTime,
                                  StatusName = paymentStatus.PaymentStatusName,
                                  TotalPrice = order.TotalPrice
                              };

            var uniqueBookings = bookingList
                .GroupBy(b => b.OrderID)
                .Select(g => g.First()) 
                .ToList();

            return Ok(uniqueBookings);
        }

        [HttpPut("update-status")]
        public IActionResult EditStatus(UpdateStatusModel updateStatusModel)
        {
            var orderToEdit = _context.Orders.FirstOrDefault(a => a.OrderID == updateStatusModel.orderID);
            orderToEdit.PaymentStatusId = updateStatusModel.StatusID;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("get_khaivi")]
        public IActionResult getAllKhaiVi()
        {
            var khaiVis = _context.MenuItems.Where(a => a.CategoryID == Guid.Parse("4b7342f3-ec78-400e-937f-cf00f19011a0")).ToList();
            return Ok(khaiVis);
        }

        [HttpGet("get_Trangmieng")]
        public IActionResult getAllget_Trangmieng()
        {
            var get_Trangmieng = _context.MenuItems.Where(a => a.CategoryID == Guid.Parse("33b81ca3-e892-4d4d-ba7d-f7a969467679")).ToList();
            return Ok(get_Trangmieng);
        }

        [HttpGet("getAll_Thit")]
        public IActionResult getAll_Thit( ){
                var getAll_Thit = _context.MenuItems.Where(a => a.CategoryID == Guid.Parse("6f578141-f837-451e-817b-a75622833a21")).ToList();
                return Ok(getAll_Thit);
         }


        [HttpGet("getAll_NuocUong")]
        public IActionResult getAll_NuocUong( )
        {
            var getAll_NuocUong = _context.MenuItems.Where(a => a.CategoryID == Guid.Parse("c0f7def7-cf7a-4d20-8061-264926f6e981")).ToList();
            return Ok(getAll_NuocUong);
        }
    }
    }
