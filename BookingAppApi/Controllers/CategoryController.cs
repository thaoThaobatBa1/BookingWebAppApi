using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Model.Model;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly BookingDbContext _context = new BookingDbContext();
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("searchCategory")]
    public async Task<IActionResult> SearchCategory(string searchText)
    {
        var menuItems = _context.Categories.Where(a => a.CategoryName.Contains(searchText)).ToList();
        return Ok(menuItems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CategoryModel categoryMD)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Guid id = Guid.NewGuid();

        var category = new Category()
        {
            CategoryID = id,
            CategoryDescription = categoryMD.CategoryDescription,
            CategoryName = categoryMD.CategoryName
            
        };


        await _categoryService.AddCategoryAsync(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryID }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryModel category)
    {
        var cate = _context.Categories.Find(id);

        cate.CategoryDescription = category.CategoryDescription;
        cate.CategoryName = category.CategoryName;

        await _categoryService.UpdateCategoryAsync(cate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}
