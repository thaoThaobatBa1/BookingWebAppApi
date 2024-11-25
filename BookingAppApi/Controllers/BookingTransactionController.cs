using BookingAppApi.Model;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BookingTransactionController : ControllerBase
{
    private readonly IBookingTransactionService _bookingTransactionService;

    public BookingTransactionController(IBookingTransactionService bookingTransactionService)
    {
        _bookingTransactionService = bookingTransactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookingTransactions()
    {
        var bookingTransactions = await _bookingTransactionService.GetAllBookingTransactionsAsync();
        return Ok(bookingTransactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingTransactionById(Guid id)
    {
        var bookingTransaction = await _bookingTransactionService.GetBookingTransactionByIdAsync(id);
        if (bookingTransaction == null)
        {
            return NotFound();
        }
        return Ok(bookingTransaction);
    }

    [HttpPost]
    public async Task<IActionResult> AddBookingTransaction([FromBody] BookingTransactionModel bookingTransactionMD)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Guid id = Guid.NewGuid();

        var bookingTransaction = new BookingTransaction()
        {
            TransactionID = id,
            PaymentID = bookingTransactionMD.PaymentID,
            TransactionDate = bookingTransactionMD.TransactionDate,
            TransactionAmount = bookingTransactionMD.TransactionAmount,
        };


        await _bookingTransactionService.AddBookingTransactionAsync(bookingTransaction);
        return CreatedAtAction(nameof(GetBookingTransactionById), new { id = bookingTransaction.TransactionID }, bookingTransaction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookingTransaction(Guid id, [FromBody] BookingTransaction bookingTransaction)
    {
        if (id != bookingTransaction.TransactionID)
        {
            return BadRequest();
        }

        await _bookingTransactionService.UpdateBookingTransactionAsync(bookingTransaction);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookingTransaction(Guid id)
    {
        await _bookingTransactionService.DeleteBookingTransactionAsync(id);
        return NoContent();
    }
}
