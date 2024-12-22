using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        public RecipesContext Context { get; }

        public RecipeIngredientsController(RecipesContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<RecipeIngredient> a = Context.RecipeIngredients.ToList();
            return Ok(a);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RecipeIngredient? a = Context.RecipeIngredients.Where(x => x.RecipeIngredientId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Add(RecipeIngredient a)
        {
            Context.RecipeIngredients.Add(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpPut]
        public IActionResult Update(RecipeIngredient a)
        {
            Context.RecipeIngredients.Update(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RecipeIngredient? a = Context.RecipeIngredients.Where(x => x.RecipeIngredientId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            Context.RecipeIngredients.Update(a);
            Context.SaveChanges();
            return Ok();
        }
    }
}
