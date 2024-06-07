using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_MathoryServer.Data;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarCountController : ControllerBase
    {
        ApplicationDbContext _context;

        public StarCountController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Read
        [HttpGet]
        public List<StarCount> GetStarCount()
        {
            List<StarCount> results = _context.StarCount
                .OrderByDescending(item => item.UserId)
                .ToList();

            return results;
        }

        //Update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateStar([FromBody] StarData data)
        {
            var user = await _context.StarCount.FindAsync(data.UserId);
            if (user == null)
            {
                return NotFound();
            }

            switch (data.UserLevel)
            {
                case 1:
                    if (data.Star > user.LevelOne)
                    {
                        user.LevelOne = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 2:
                    if (data.Star > user.LevelTwo)
                    {
                        user.LevelTwo = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 3:
                    if (data.Star > user.LevelThree)
                    {
                        user.LevelThree = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 4:
                    if (data.Star > user.LevelFour)
                    {
                        user.LevelFour = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 5:
                    if (data.Star > user.LevelFive)
                    {
                        user.LevelFive = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 6:
                    if (data.Star > user.LevelSix)
                    {
                        user.LevelSix = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 7:
                    if (data.Star > user.LevelSeven)
                    {
                        user.LevelSeven = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 8:
                    if (data.Star > user.LevelEight)
                    {
                        user.LevelEight = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 9:
                    if (data.Star > user.LevelNine)
                    {
                        user.LevelNine = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 10:
                    if (data.Star > user.LevelTen)
                    {
                        user.LevelTen = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 11:
                    if (data.Star > user.LevelEleven)
                    {
                        user.LevelEleven = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
                case 12:
                    if (data.Star > user.LevelTwelve)
                    {
                        user.LevelTwelve = data.Star;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    break;
            }

            return NoContent();
        }

    }

    public class StarData
    {
        public string UserId { get; set; }
        public int UserLevel { get; set; }
        public int Star { get; set; }
    }
}
