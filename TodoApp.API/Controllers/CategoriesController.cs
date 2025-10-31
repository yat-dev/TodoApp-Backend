namespace TodoApp.API.Controllers;

[Authorize]
public class CategoriesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAll([FromServices] ISender mediator)
    {
        var result = await mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command, [FromServices] ISender mediator)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromServices] ISender mediator, [FromRoute] int id)
    {
        try
        {
            await mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}