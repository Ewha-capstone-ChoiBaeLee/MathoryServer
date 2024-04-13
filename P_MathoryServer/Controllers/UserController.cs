using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE

        // READ
        /*[HttpGet]
        public List<UserInformation> GetUsersInformation()
        {
            List<UserInformation> results = _context.UserInformation
                .OrderByDescending(item => item.UserLevel)
                .ToList();

            return results;
        }

        [HttpGet("{id}")]
        public UserInformation GetUserInformation(int id)
        {
            UserInformation result = _context.UserInformation
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }*/

        // UPDATE

        // DELETE
    }
}
