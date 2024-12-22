using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        public RecipesContext Context { get; }

        public IngredientsController(RecipesContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ingredient> a = Context.Ingredients.ToList();
            return Ok(a);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ingredient? a = Context.Ingredients.Where(x => x.IngredientId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Add(Ingredient a)
        {
            Context.Ingredients.Add(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpPut]
        public IActionResult Update(Ingredient a)
        {
            Context.Ingredients.Update(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Ingredient? a = Context.Ingredients.Where(x => x.IngredientId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            Context.Ingredients.Update(a);
            Context.SaveChanges();
            return Ok();
        }
    }
}

