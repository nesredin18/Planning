using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.user;
using MediatR;

namespace Todo.core.usecases.UserUse
{
    public class UserUseCase
    {
        
    }
        public class GetUserByEmailQ : IRequest<ApplicationUser>
    {
        public string Email { get; }

        public GetUserByEmailQ(string email)
        {
            Email = email;
        }
    }
}