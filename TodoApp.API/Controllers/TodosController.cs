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
        // var result = await Mediator.Send(new GetPendingTodosQuery());
        // return Ok(result);
        return null!;
    }
    
    [HttpGet("completed")]
    public async Task<ActionResult<List<TodoItemDto>>> GetCompleted()
    {
        // var result = await Mediator.Send(new GetCompletedTodosQuery());
        // return Ok(result);
        return null!;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDto>> GetById(int id)
    {
        // try
        // {
        //     var result = await Mediator.Send(new GetTodoByIdQuery { Id = id });
        //     return Ok(result);
        // }
        // catch (NotFoundException)
        // {
        //     return NotFound();
        // }
        return null!;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCategoryCommand command, [FromServices] ISender mediator)
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