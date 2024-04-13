using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE

        // READ
        [HttpGet]
        public List<Quiz> GetQuiz()
        {
            List<Quiz> results = _context.Quiz
                .OrderBy(item => item.Id)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public Quiz GetQuiz(int id)
        {
            Quiz result = _context.Quiz
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }

        // UPDATE

    }
}
