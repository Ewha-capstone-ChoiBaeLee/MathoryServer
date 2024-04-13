using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {   
            _context = context;
        }

        // CREATE

        // READ
        /*[HttpGet]
        public List<CharacterInformation> GetCharactersInformation()
        {
            List<CharacterInformation> results = _context.CharacterInformation
                .OrderByDescending(item => item.CharacterId)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public CharacterInformation GetCharacterInformation(int id)
        {
            CharacterInformation result = _context.CharacterInformation
                .Where(item => item.CharacterId == id)
                .FirstOrDefault();

            return result;
        }*/

        // UPDATE

        // DELETE
    }
}
