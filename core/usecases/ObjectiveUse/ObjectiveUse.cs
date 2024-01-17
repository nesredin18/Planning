using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity.user;

namespace Todo.core.usecases.ObjectiveUse
{
    public class ObjectiveUse
    {
        
    }
    public class CreateObjective:IRequest<int>
    {
        public string Ob_Name { get; set; }=string.Empty;

        public string Ob_Description { get; set; }=string.Empty;
        public ICollection<ApplicationUser> AppUsers { get; set; } = [];

    
    }
}