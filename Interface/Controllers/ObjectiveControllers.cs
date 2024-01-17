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
    command.AppUsers.Add(c);
    var taskId = await _mediator.Send(command);
     return Ok(taskId);
    }
        
        return BadRequest("error");
    }
    }
}