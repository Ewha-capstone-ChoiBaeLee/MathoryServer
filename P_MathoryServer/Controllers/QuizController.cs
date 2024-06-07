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

        public class LevelData
        {
            public int Level { get; set; }
        }

        [HttpGet]
        public List<Quiz> GetQuiz()
        {
            List<Quiz> results = _context.Quiz
                .OrderByDescending(item => item.Part)
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



        [HttpPost]
        public IActionResult Post([FromBody] LevelData data)
        {
            if (data == null)
            {
                return BadRequest("Data is null");
            }

            Console.WriteLine($"Received Level: {data.Level}");

            if (data.Level == 1)
            {
                QuizEquation.Year = 1;
                Console.WriteLine($"Received Year: 1");
            }
            else if(data.Level == 3)
            {
                QuizEquation.Year = 2;
                Console.WriteLine($"Received Year: 2");
            }
            else if (data.Level == 5)
            {
                QuizEquation.Year = 3;
                Console.WriteLine($"Received Year: 3");
            }
            else if (data.Level == 7)
            {
                QuizEquation.Year = 4;
                Console.WriteLine($"Received Year: 4");
            }
            else if (data.Level == 9)
            {
                QuizEquation.Year = 5;
                Console.WriteLine($"Received Year: 5");
            }
            else if (data.Level == 11)
            {
                QuizEquation.Year = 6;
                Console.WriteLine($"Received Year: 6");
            }

            return Ok(new { message = "Data received and shared data updated successfully" });
        }
    }
}
