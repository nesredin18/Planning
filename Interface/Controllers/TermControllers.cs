using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Todo.core.usecases.termuse;
using Todo.core;
using Todo.core.entity.Objectives;


namespace Todo.Interface.Controllers
{
[ApiController]
[Route("/term")]
    public class TermControllers:ControllerBase
    {
        private readonly IMediator _mediator;

    public TermControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
   [Authorize]
    [HttpPost]

    
    public async Task<ActionResult<int>> CreateTask([FromBody] CreateTerm command)
    {


    command.Initial_date = DateTimeExtensions.SetKindUtc(command.Initial_date);
    command.Final_date=DateTimeExtensions.SetKindUtc(command.Final_date);
    var taskId = await _mediator.Send(command);
     return Ok(taskId);
    }

[HttpGet]
public async Task<ActionResult<IEnumerable<TermModel>>> GetAllTasks()
{
    var tasks = await _mediator.Send(new GetAllTermQuery());
    return Ok(tasks);
}
[Authorize]
[HttpGet("{id}")]
public async Task<ActionResult<ObjectiveModel>> GetTaskById(int id)
    {
       
var task = await _mediator.Send(new GetTermByIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}

[HttpGet("get/{id}")]
public async Task<ActionResult<ObjectiveModel>> GettermById(int id)
    {
       
var task = await _mediator.Send(new GetTermByObjIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}
[Authorize]
[HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTermCommand command)
    {

        command.Id=id;
        command.Initial_date = DateTimeExtensions.SetKindUtc(command.Initial_date);
        command.Final_date=DateTimeExtensions.SetKindUtc(command.Final_date);

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
    var command = new DeleteTermCommand { Id = id };
    var result = await _mediator.Send(command);
    if (!result)
    {
        return NotFound();
    }

    return NoContent();
}
    
    }
}