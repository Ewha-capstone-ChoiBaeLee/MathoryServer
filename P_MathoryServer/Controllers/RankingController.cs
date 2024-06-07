using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE

        // READ
        [HttpGet]
        public List<Ranking> GetRanking()
        {
            List<Ranking> results = _context.Ranking
                .OrderBy(item => item.Id)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public Ranking GetRanking(int id)
        {
            Ranking result = _context.Ranking
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }

        // UPDATE

        // DELETE
    }
}
