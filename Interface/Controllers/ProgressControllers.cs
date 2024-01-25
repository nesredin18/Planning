using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.core;
using Todo.core.entity.Objectives;
using Todo.core.usecases.Activityuse;
using Todo.core.usecases.ObjectiveUse;
using Todo.core.usecases.progressuse;

namespace Todo.Interface.Controllers
{


[ApiController]
[Route("/progress")]
    public class ProgressControllers:ControllerBase
    {
        private readonly IMediator _mediator;

    public ProgressControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
[Authorize]
    [HttpPost]

    
    public async Task<ActionResult<int>> CreateTask([FromBody] CreateOP command)
    {
    var c= await _mediator.Send(new GetObjByIdQuery(command.Objective_id));
    if(c==null)
    {
        return BadRequest("There is no Object with this Id");
    }

    command.Objective=c;

    command.Done_date = DateTimeExtensions.SetKindUtc(command.Done_date);
    var taskId = await _mediator.Send(command);
     return Ok(taskId);
    }

[Authorize]
    [HttpPost("/AP")]

    
    public async Task<ActionResult<int>> CreateAPTask([FromBody] CreateP command)
    {
    var c= await _mediator.Send(new GetActByIdQuery(command.Objective_id));
    if(c==null)
    {
        return BadRequest("There is no Object with this Id");
    }

    command.Activity=c;

    command.Done_date = DateTimeExtensions.SetKindUtc(command.Done_date);
    var taskId = await _mediator.Send(command);
     return Ok(taskId);
    }

[HttpGet]
public async Task<ActionResult<IEnumerable<ObjectiveProgress>>> GetAllTasks()
{
    var tasks = await _mediator.Send(new GetAllOPQuery());
    return Ok(tasks);
}
[HttpGet("/AP")]
public async Task<ActionResult<IEnumerable<ActivityProgress>>> GetAllAP()
{
    var tasks = await _mediator.Send(new GetAllAPQuery());
    return Ok(tasks);
}

[Authorize]
[HttpGet("{id}")]
public async Task<ActionResult<ObjectiveProgress>> GetTaskById(int id)
    {
       
var task = await _mediator.Send(new GetOPByIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}
[Authorize]
[HttpGet("AP/{id}")]
public async Task<ActionResult<ActivityProgress>> GetTAPById(int id)
    {
       
var task = await _mediator.Send(new GetAPByIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}
[Authorize]
[HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateOPCommand command)
    {

        command.Id=id;
        command.Done_date = DateTimeExtensions.SetKindUtc(command.Done_date);

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
}
[Authorize]
[HttpPut("AP/{id}")]
    public async Task<IActionResult> UpdateAP(int id, [FromBody] UpdatePCommand command)
    {

        command.Id=id;
        command.Done_date = DateTimeExtensions.SetKindUtc(command.Done_date);

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
    var command = new DeleteOPCommand { Id = id };
    var result = await _mediator.Send(command);
    if (!result)
    {
        return NotFound();
    }

    return NoContent();
}
[Authorize]
[HttpDelete("AP/{id}")]
public async Task<IActionResult> DeleteAP(int id)
{
    var command = new DeletePCommand { Id = id };
    var result = await _mediator.Send(command);
    if (!result)
    {
        return NotFound();
    }

    return NoContent();
}
    
    }
}