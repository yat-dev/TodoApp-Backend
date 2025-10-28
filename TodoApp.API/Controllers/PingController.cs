namespace TodoApp.API.Controllers;

public class PingController : BaseApiController
{
    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok("pong");
    }
}