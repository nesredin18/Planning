using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.user;
using MediatR;
using Todo.core.entity;
using Todo.core.usecases.UserUse;
namespace Todo.core.usecases.UserUse
{
    public class UserHandler
    {
        
    }

    public class GetUserByEmailQHandler : IRequestHandler<GetUserByEmailQ, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(GetUserByEmailQ request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByEmail(request.Email);
        }
    }
}