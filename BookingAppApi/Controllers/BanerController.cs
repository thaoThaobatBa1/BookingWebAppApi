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
    public class BanerController : ControllerBase
    {
        private readonly IBanerSevice _banerSv;

        private readonly BookingDbContext _context;

        public BanerController(IBanerSevice Service, BookingDbContext context)
        {
            _banerSv = Service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaner()
        {
            var menuItems = await _banerSv.GetAllAsync();
            return Ok(menuItems);
        }

            
        [HttpPost]
        public async Task<IActionResult> AddMenuItem( IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banerItem = new Baner();

            if (imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Baners", imageFile.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await imageFile.CopyToAsync(stream);
                }

                banerItem.Banerimg = "/Baners/" + imageFile.FileName;
            }
            else
            {
                banerItem.Banerimg = "";
            }

            try
            {
                await _context.Baners.AddAsync(banerItem);
                await _context.SaveChangesAsync();
                return Ok(banerItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(Guid id)
        {
            await _banerSv.DeleteAsync(id);
            return NoContent();
        }
    }
}
