using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MyPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE

        // READ
        [HttpGet]
        public List<MyPage> GetMyPages()
        {
            List<MyPage> results = _context.MyPage
                .Include(mp => mp.UserInformation)  // UserInformation 엔티티를 포함
                .Include(mp => mp.Subject)          // Subject 엔티티를 포함
                .OrderByDescending(item => item.UserId)
                .ToList();

            return results;
        }

        [HttpGet("{UserId}")]
        public MyPage GetMyPage(string UserId)
        {
            MyPage result = _context.MyPage
                .Include(mp => mp.UserInformation)  // UserInformation 엔티티를 포함
                .Include(mp => mp.Subject)          // Subject 엔티티를 포함
                .Where(item => item.UserId == UserId)
                .FirstOrDefault();

            return result;
        }

        // UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> UpdateQuestions([FromBody] QuizData data)
        {
            var user = await _context.MyPage
                .FirstOrDefaultAsync(u => u.UserId == data.UserId && u.Year == data.Year && u.SubjectId == data.SubjectId);

            if (user == null)
            {
                return NotFound();
            }

            user.Correct_Questions += data.Corrected_Num;
            user.Solved_Questions += data.Solved_Num;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
    }

    public class QuizData
    {
        public string UserId { get; set; }
        public int Year { get; set; }
        public int SubjectId { get; set; }
        public int Solved_Num { get; set; }
        public int Corrected_Num { get; set; }
    }
}
