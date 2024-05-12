using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToggleStatusController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post(List<int> toggleStatuses)
        {
            // 받은 데이터 활용
            if (toggleStatuses != null)
            {
                Prompts.selectFriends = toggleStatuses;
            }

            // 응답
            return Ok("Toggle statuses received successfully.");
        }
    }
}
