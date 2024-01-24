using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Todo.core.usecases.Activityuse;
using Todo.core.usecases.ObjectiveUse;
using Todo.core.entity.Objectives;
using Todo.core;

namespace Todo.Interface.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityControllers : ControllerBase
    {
         private readonly IMediator _mediator;

    public ActivityControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize]
    [HttpPost]

    
    public async Task<ActionResult<int>> CreateTask([FromBody] CreateAct command)
    {

    var c= await _mediator.Send(new GetObjByIdQuery(command.Objective_id));
    if(c==null)
    {
        return BadRequest("There is no Object with this Id");
    }
    command.Initial_date = DateTimeExtensions.SetKindUtc(command.Initial_date);
    command.Final_date=DateTimeExtensions.SetKindUtc(command.Final_date);
    command.Objectives.Add(c);
    var taskId = await _mediator.Send(command);
     return Ok(taskId);
    }
        

[HttpGet]
public async Task<ActionResult<IEnumerable<ActivityModel>>> GetAllTasks()
{
    var tasks = await _mediator.Send(new GetAllActQuery());
    return Ok(tasks);
}
[Authorize]
[HttpGet("{id}")]
public async Task<ActionResult<ActivityModel>> GetTaskById(int id)
    {
       
var task = await _mediator.Send(new GetActByIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}
[Authorize]
[HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateActCommand command)
    {

        command.Id=id;

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
}
[Authorize]
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteTask(int id)
{
    var command = new DeleteActCommand { Id = id };
    var result = await _mediator.Send(command);
    if (!result)
    {
        return NotFound();
    }

    return NoContent();
}
    }
}