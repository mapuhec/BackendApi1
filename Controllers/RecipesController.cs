using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public RecipesContext Context { get; }

        public RecipesController(RecipesContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Recipe> a = Context.Recipes.ToList();
            return Ok(a);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Recipe? a = Context.Recipes.Where(x => x.RecipeId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Add(Recipe a)
        {
            Context.Recipes.Add(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpPut]
        public IActionResult Update(Recipe a)
        {
            Context.Recipes.Update(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Recipe? a = Context.Recipes.Where(x => x.RecipeId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            Context.Recipes.Update(a);
            Context.SaveChanges();
            return Ok();
        }
    }
}
