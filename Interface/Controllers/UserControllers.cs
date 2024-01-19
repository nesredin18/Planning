using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Todo.core.usecases.taskuse;
using Todo.core.entity.task;
using Todo.core.entity.user;
using Microsoft.AspNetCore.Identity;
using Todo.Interface.dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Todo.Interface.Controllers
{
    public class UserControllers
    {
        
    }

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok();  // Or any other appropriate response
        }

        return BadRequest(result.Errors);
    }



[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginModel model)
{   
    var user = await _userManager.FindByEmailAsync(model.Email);

    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
    {
        if (user.Email == null)
        {
            return Unauthorized();
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyMustBeVerySecretThatNoOneMustKnow")); // Replace with your secret key
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            // add other claims as needed
        };

        var token = new JwtSecurityToken(
            issuer: "yourdomain.com", // Replace with your issuer
            audience: "yourdomain.com", // Replace with your audience
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return Ok(new 
        { 
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo 
        });
    }

    return Unauthorized();
}

[Authorize]
[HttpGet("username")]
public IActionResult GetUsername()
{
    var claimsIdentity = User.Identity as ClaimsIdentity;
    if (claimsIdentity != null)
    {
        var emailClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (emailClaim != null)
        {
            // Return a JSON response with the email
            return Ok(new { Email = emailClaim });
        }
        return BadRequest("Email claim not found.");
    }

    return BadRequest("User is not authenticated.");
}




    // ... Login method
}

}