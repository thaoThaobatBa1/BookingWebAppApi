using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    private readonly BookingDbContext _context = new BookingDbContext();

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMenus()
    {
        var menus = await _menuService.GetAllMenusAsync();
        return Ok(menus);
    }
    [HttpGet("searchMenu")]
    public async Task<IActionResult> SearchCategory(string searchText)
    {
        var menuItems = _context.Menus.Where(a => a.MenuName.Contains(searchText)).ToList();
        return Ok(menuItems);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenuById(Guid id)
    {
        var menu = await _menuService.GetMenuByIdAsync(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> AddMenu([FromBody] MenuModel menuMD)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Guid id = Guid.NewGuid();

        var menu = new Menu()
        {
            MenuID = id,
            Description = menuMD.Description,
            MenuName = menuMD.MenuName
        };


        await _menuService.AddMenuAsync(menu);
        return CreatedAtAction(nameof(GetMenuById), new { id = menu.MenuID }, menu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenu(Guid id, [FromBody] MenuModel menuMd)
    {
        var menu = _context.Menus.Find(id);

        menu.MenuName = menuMd.MenuName;
        menu.Description = menuMd.Description;

        await _menuService.UpdateMenuAsync(menu);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(Guid id)
    {
        await _menuService.DeleteMenuAsync(id);
        return NoContent();
    }
}
