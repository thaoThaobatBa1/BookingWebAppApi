using BookingAppApi.Model;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableSevice _tableService;

        public TableController(ITableSevice tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetAllTables()
        {
            var tables = await _tableService.GetAllTablesAsync();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTableById(Guid id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTable(TableModel tableMD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Table table = new Table()
            {
                TableID = new Guid(),
                Seats = tableMD.Seats,
                Location = tableMD.Location,
                TableNumber = tableMD.TableNumber,
                Price = tableMD.Price
            };

            await _tableService.AddTableAsync(table);
            return CreatedAtAction(nameof(GetTableById), new { id = table.TableID }, table);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTable(Guid id, [FromBody] Table table)
        {
            if (id != table.TableID)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTable = await _tableService.GetTableByIdAsync(id);
            if (existingTable == null)
            {
                return NotFound();
            }

            await _tableService.UpdateTableAsync(table);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTable(Guid id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            await _tableService.DeleteTableAsync(id);
            return NoContent();
        }

    }
}
