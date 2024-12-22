using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRecipesController : ControllerBase
    {
        public class FavoriteRecipeController : ControllerBase
        {
            public RecipesContext Context { get; }

            public FavoriteRecipeController(RecipesContext context)
            {
                Context = context;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                List<FavoriteRecipe> a = Context.FavoriteRecipes.ToList();
                return Ok(a);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                FavoriteRecipe? a = Context.FavoriteRecipes.Where(x => x.FavoriteId == id).FirstOrDefault();
                if (a == null)
                {
                    return BadRequest("Not Found");
                }
                return Ok(a);
            }
            [HttpPost]
            public IActionResult Add(FavoriteRecipe a)
            {
                Context.FavoriteRecipes.Add(a);
                Context.SaveChanges();
                return Ok(a);
            }
            [HttpPut]
            public IActionResult Update(FavoriteRecipe a)
            {
                Context.FavoriteRecipes.Update(a);
                Context.SaveChanges();
                return Ok(a);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                FavoriteRecipe? a = Context.FavoriteRecipes.Where(x => x.FavoriteId == id).FirstOrDefault();
                if (a == null)
                {
                    return BadRequest("Not Found");
                }
                Context.FavoriteRecipes.Update(a);
                Context.SaveChanges();
                return Ok();
            }
        }
    }
}
