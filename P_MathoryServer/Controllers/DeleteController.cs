using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_MathoryServer.Data;

[Route("api/[controller]")]
[ApiController]
public class DeleteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DeleteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // DELETE: api/Delete
    [HttpDelete]
    public async Task<ActionResult> DeleteAll()
    {
        try
        {
            //quiz 삭제
            var quiz = await _context.Quiz.ToListAsync();
            _context.Quiz.RemoveRange(quiz);

            var story = await _context.Story.ToListAsync();
            _context.Story.RemoveRange(story);

            var storyline = await _context.StoryLine.ToListAsync();
            _context.StoryLine.RemoveRange(storyline);
            await _context.SaveChangesAsync();

            return Ok("All quiz/story/storyLine records deleted successfully.");

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error deleting quiz records: {ex.Message}");
        }
    }
}