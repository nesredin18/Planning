using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Todo.core.usecases.taskuse;
using Todo.core.entity.task;

namespace Todo.Interface.Controllers
{

[Route("/api/task")]
[ApiController]
public class TaskControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateTask([FromBody] CreateTaskCommand command)
    {
            if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
        var taskId = await _mediator.Send(command);
        return Ok(taskId);
    }
[HttpGet]
public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTasks()
{
    var tasks = await _mediator.Send(new GetAllTasksQuery());
    return Ok(tasks);
}

[HttpGet("{id}")]
public async Task<ActionResult<TaskModel>> GetTaskById(int id)
    {
       
var task = await _mediator.Send(new GetTaskByIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskCommand command)
    {

        command.Id=id;

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteTask(int id)
{
    var command = new DeleteTaskCommand { Id = id };
    var result = await _mediator.Send(command);
    if (!result)
    {
        return NotFound();
    }

    return NoContent();
}


}


    }
    
