using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.user;

namespace Todo.core.entity
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByEmail(string email);
    }
}