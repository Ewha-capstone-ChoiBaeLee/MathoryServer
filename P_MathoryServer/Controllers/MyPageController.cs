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

        // DELETE
    }
}
