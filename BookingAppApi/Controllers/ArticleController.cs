using BookingAppApi.Model;
using BookingShop.Data;
using BookingShop.Sevice.ISeivces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleSevice _sv;
        private readonly BookingDbContext _context;

        public ArticleController(IArticleSevice sv, BookingDbContext context)
        {
            _sv = sv;
            _context = context;
        }

        [HttpGet("get-all-article")]
        public async Task< IActionResult> GetAll() { 
            var list = await _sv.GetAllAsync();
            return Ok(list);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putArticle(Guid id,ArticleModel articleModel) {
            var article = await _sv.GetByIdAsync(id);
            article.ArticleContent = articleModel.articleContent;
            _sv.UpdateAsync(article);
            return Ok();
        }



    }
}
