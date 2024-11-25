using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    private readonly BookingDbContext _context;

    public MenuItemController(IMenuItemService menuItemService, BookingDbContext context)
    {
        _menuItemService = menuItemService;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMenuItems()
    {
       var menuItems = await _menuItemService.GetAllMenuItemsAsync();
        return Ok(menuItems);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string searchText)
    {
        var menuItems = _context.MenuItems.Where(a => a.ItemName.Contains(searchText)).ToList();    
        return Ok(menuItems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenuItemById(Guid id)
    {
        var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
        if (menuItem == null)
        {
            return NotFound();
        }
        return Ok(menuItem);
    }
    [HttpPost]
    public async Task<IActionResult> AddMenuItem([FromForm] MenuItemModel menuItemMD,IFormFile imageFile)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var menuItem = new MenuItem()
        {
            MenuItemID = new Guid(),
            Description = menuItemMD.Description,
            Available = menuItemMD.Available,
            CategoryID = menuItemMD.CategoryID,
            ItemName = menuItemMD.ItemName,
            MenuID = menuItemMD.MenuID,
            Price = menuItemMD.Price

        };

        if (imageFile.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "images", imageFile.FileName);
            using(var stream = System.IO.File.Create(path))
            {
                await imageFile.CopyToAsync(stream);
            }

            menuItem.ImageMenuItem = "/images/" + imageFile.FileName;
        }
        else
        {
            menuItem.ImageMenuItem = "";
        }

        try
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
            return Ok(menuItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenuItem(Guid id, [FromForm]  MenuItemModel menuItemMD, IFormFile imageFile)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var menuItem = _context.MenuItems.Find(id);

        menuItem.Description = menuItemMD.Description;
        menuItem.Available = menuItemMD.Available;
        menuItem.CategoryID = menuItemMD.CategoryID;
        menuItem.ItemName = menuItemMD.ItemName;
        menuItem.MenuID = menuItemMD.MenuID;
        menuItem.Price = menuItemMD.Price;


        if (imageFile.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
            using (var stream = System.IO.File.Create(path))
            {
                await imageFile.CopyToAsync(stream);
            }

            menuItem.ImageMenuItem = "/images/" + imageFile.FileName;
        }
        else
        {
            menuItem.ImageMenuItem = "";
        }

        try
        {
         
            await _context.SaveChangesAsync();
            return Ok(menuItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenuItem(Guid id)
    {
        await _menuItemService.DeleteMenuItemAsync(id);
        return NoContent();
    }
}
