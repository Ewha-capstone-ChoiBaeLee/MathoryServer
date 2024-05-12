using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        ApplicationDbContext _context;

        public StoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE

        // READ
        [HttpGet]
        public List<Story> GetStory()
        {
            List<Story> results = _context.Story
                .OrderBy(item => item.Id)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public Story GetStoryLine(int id)
        {
            Story result = _context.Story
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }

        // UPDATE

        // DELETE
    }
}
