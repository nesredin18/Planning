using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.Objectives;

using Microsoft.AspNetCore.Identity;

namespace Todo.core.entity.user
{

    public class UserModel{
        
    }


    public class ApplicationUser : IdentityUser
{
    // Additional properties, if needed
    public ICollection<ObjectiveModel> Objectives { get; set; } = [];
}
}