using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public RecipesContext Context { get; }

        public CategoriesController(RecipesContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> a = Context.Categories.ToList();
            return Ok(a);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category? a = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Add(Category a)
        {
            Context.Categories.Add(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpPut]
        public IActionResult Update(Category a)
        {
            Context.Categories.Update(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category? a = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            Context.Categories.Update(a);
            Context.SaveChanges();
            return Ok();
        }
    }
}
