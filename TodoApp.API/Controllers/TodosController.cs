namespace TodoApp.API.Controllers;

[Authorize]
public class TodosController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<TodoItemDto>>> GetAll([FromServices] ISender mediator)
    {
        var result = await mediator.Send(new GetAllTodosQuery());
        return Ok(result);
    }

    [HttpGet("pending")]
    public async Task<ActionResult<List<TodoItemDto>>> GetPending([FromServices] ISender mediator)
    {
        var result = await mediator.Send(new GetPendingTodosQuery());
        return Ok(result);
    }
    
    [HttpGet("completed")]
    public async Task<ActionResult<List<TodoItemDto>>> GetCompleted([FromServices] ISender mediator)
    {
        var result = await mediator.Send(new GetCompletedTodosQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDto>> GetById(int id, [FromServices] ISender mediator)
    {
        try
        {
            var result = await mediator.Send(new GetTodoByIdQuery { Id = id });
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateTodoCommand command, [FromServices] ISender mediator)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromBody] UpdateTodoCommand command, [FromServices] ISender mediator)
    {
        try
        {
            await mediator.Send(command);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromBody] DeleteTodoCommand command, [FromServices] ISender mediator)
    {
        try
        {
            await mediator.Send(command);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}