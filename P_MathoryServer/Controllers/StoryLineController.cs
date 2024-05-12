using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryLineController : ControllerBase
    {
        ApplicationDbContext _context;

        public StoryLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE

        // READ
        [HttpGet]
        public List<StoryLine> GetStoryLine()
        {
            List<StoryLine> results = _context.StoryLine
                .OrderBy(item => item.Id)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public StoryLine GetStoryLine(int id)
        {
            StoryLine result = _context.StoryLine
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }

        // UPDATE

        // DELETE

    }
}
