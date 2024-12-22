using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public RecipesContext Context { get; }

        public ReviewsController(RecipesContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> a = Context.Reviews.ToList();
            return Ok(a);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Review? a = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Add(Review a)
        {
            Context.Reviews.Add(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpPut]
        public IActionResult Update(Review a)
        {
            Context.Reviews.Update(a);
            Context.SaveChanges();
            return Ok(a);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Review? a = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (a == null)
            {
                return BadRequest("Not Found");
            }
            Context.Reviews.Update(a);
            Context.SaveChanges();
            return Ok();
        }
    }
}
