using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Todo.core.entity.task;
using Todo.core.entity.user;
using Todo.Interface.dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Todo.core.usecases.ObjectiveUse;
using Todo.core.usecases.UserUse;
using Todo.core.entity.Objectives;
using Todo.core;


namespace Todo.Interface.Controllers
{
 [ApiController]
[Route("/objective")]
    public class ObjectiveControllers:ControllerBase
    {
        private readonly IMediator _mediator;

    public ObjectiveControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<int>> CreateTask([FromBody] CreateObjective command)
    {
        if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    var claimsIdentity = User.Identity as ClaimsIdentity;
    if (claimsIdentity != null)
    {
        // Extract username or other claims
        var emailClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(emailClaim==null)
        {
            return BadRequest("error");
        }
        var c=await _mediator.Send(new GetUserByEmailQ(emailClaim));
        command.Initial_date = DateTimeExtensions.SetKindUtc(command.Initial_date);
        command.Final_date=DateTimeExtensions.SetKindUtc(command.Final_date);
        command.AppUsers.Add(c);
        var taskId = await _mediator.Send(command);
        return Ok(taskId);
    }
        
        return BadRequest("error");
    }

[HttpGet]
public async Task<ActionResult<IEnumerable<ObjectiveModel>>> GetAllTasks()
{
    var tasks = await _mediator.Send(new GetAllObjQuery());
    return Ok(tasks);
}
[Authorize]
[HttpGet("{id}")]
public async Task<ActionResult<ObjectiveModel>> GetTaskById(int id)
    {
       
var task = await _mediator.Send(new GetObjByIdQuery(id));
if (task == null)
{
return NotFound();
}

return Ok(task);
}
[Authorize]
[HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateObjCommand command)
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
[HttpPut("addterm/{id}")]
    public async Task<IActionResult> UpdateTaskterm(int id, [FromBody] CreateObjectiveTerm command)
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
    var command = new DeleteObjCommand { Id = id };
    var result = await _mediator.Send(command);
    if (!result)
    {
        return NotFound();
    }

    return NoContent();
}
    
    }
}