using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Todo.core.entity.user;
using Todo.core.entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBcontext _context;
        public UserRepository(ApplicationDBcontext context)
        {
            _context = context;
        }
public async Task<ApplicationUser> GetUserByEmail(string email)
{
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    if (user == null)
    {
        throw new KeyNotFoundException($"User with email {email} not found.");
    }
    return user;
}

    }
}