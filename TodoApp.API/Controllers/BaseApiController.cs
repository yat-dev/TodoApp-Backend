namespace TodoApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private ISender _mediatr = null!;
    public ISender Mediatr => _mediatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}