using Domain.Entities;
using Domain.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogContext context;

        public BlogController(BlogContext context)
            => this.context = context;

        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            tvar result = await context.BlogPosts.AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await context.BlogPosts.AsNoTracking()
                .Where(blog => blog.Id == id)
                .SingleOrDefaultAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<BlogController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogPost model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var entity = context.BlogPosts.Add(model).Entity;
            await context.SaveChangesAsync();

            return Ok(entity);
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BlogPost model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var entity = await context.BlogPosts.SingleOrDefaultAsync(blog => blog.Id == id);
            if (entity == null)
                return NotFound(entity);

            entity.Title = model.Title;
            entity.Summary = model.Summary;
            entity.Body = model.Body;
            await context.SaveChangesAsync();

            return Ok(entity);
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await context.BlogPosts.AnyAsync(blog => blog.Id == id))
                return NotFound();

            context.BlogPosts.Remove(new BlogPost { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
