using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly BookingDbContext _context;

    public OrderDetailController(IOrderDetailService orderDetailService, BookingDbContext context)
    {
        _orderDetailService = orderDetailService;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrderDetails()
    {
        var orderDetails = await _orderDetailService.GetAllOrderDetailsAsync();
        return Ok(orderDetails);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(Guid id)
    {
        var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);
        if (orderDetail == null)
        {
            return NotFound();
        }
        return Ok(orderDetail);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetailModel orderDetailMD)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var exitOderDetail = _context.OrderDetails.FirstOrDefault(a => a.MenuItemID == orderDetailMD.MenuItemID);
        if (exitOderDetail != null)
        {
            exitOderDetail.Quantity = exitOderDetail.Quantity + orderDetailMD.Quantity;
            exitOderDetail.Price = exitOderDetail.Price + (orderDetailMD.Quantity * _context.MenuItems.FirstOrDefault(a => a.MenuItemID == orderDetailMD.MenuItemID).Price);
            _context.SaveChanges();
            _context.Orders.FirstOrDefault(a => a.OrderID == orderDetailMD.OrderID).TotalPrice += (orderDetailMD.Quantity * _context.MenuItems.FirstOrDefault(a => a.MenuItemID == orderDetailMD.MenuItemID).Price);
            _context.SaveChanges();
            
            return Ok(exitOderDetail);
        }
        else
        {
            var orderDetail = new OrderDetail()
            {
                OrderDetailID = new Guid(),
                MenuItemID = orderDetailMD.MenuItemID,
                OrderID = orderDetailMD.OrderID,
                Quantity = orderDetailMD.Quantity,
                Price = _context.MenuItems.FirstOrDefault(a => a.MenuItemID == orderDetailMD.MenuItemID).Price * orderDetailMD.Quantity,
            };

            await _orderDetailService.AddOrderDetailAsync(orderDetail);
            _context.Orders.FirstOrDefault(a => a.OrderID == orderDetail.OrderID).TotalPrice += orderDetail.Quantity * _context.MenuItems.FirstOrDefault(a => a.MenuItemID == orderDetailMD.MenuItemID).Price;
            return Ok(orderDetail);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderDetail(Guid id, [FromBody] OrderDetail orderDetail)
    {
        if (id != orderDetail.OrderDetailID)
        {
            return BadRequest();
        }

        await _orderDetailService.UpdateOrderDetailAsync(orderDetail);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(Guid id)
    {
        await _orderDetailService.DeleteOrderDetailAsync(id);
        return NoContent();
    }
}
