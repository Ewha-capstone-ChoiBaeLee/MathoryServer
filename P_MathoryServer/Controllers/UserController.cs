using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_MathoryServer.Data;
using SharedData.Models;
using static P_MathoryServer.Controllers.QuizController;

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
        [HttpPost]
        public IActionResult AddUserInformation([FromBody] UserInformation newUser)
        {
            try
            {
                _context.UserInformation.Add(newUser);
                _context.SaveChanges();

                //return Ok("User information added successfully!");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add user information: " + ex.Message);
            }
        }

        // READ
        [HttpGet]
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
        }

        // UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> UpdateLevel([FromBody] LevelData2 data)
        {
            var user = await _context.UserInformation
                                 .FirstOrDefaultAsync(u => u.UserId == data.UserId);
            if (user == null)
            {
                return NotFound();
            }

            if(data.UserLevel < 12)
            {
                user.UserLevel += data.Increment;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE
    }

    public class LevelData2
    {
        public string UserId { get; set; }
        public int UserLevel { get; set; }
        public int Increment { get; set; }
    }
}
