using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity.Objectives;
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
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;

        public ICollection<TermModel> Terms { get; set; } = [];
        public int[] Term_Id { get; set; }=[];

    
    }

    public class CreateObjectiveTerm:IRequest<bool>
    {


        public int Id { get; set; }
        public int Term_Id { get; set; }

    
    }
    public class GetObjByIdQuery : IRequest<ObjectiveModel>
    {
        public int Id { get; }

        public GetObjByIdQuery(int id)
        {
            Id = id;
        }
    }
public class UpdateObjCommand : IRequest<bool>
{
       public int Id { get; set; }  // Include the ID
        public string Ob_Name { get; set; }=string.Empty;

        public string Ob_Description { get; set; }=string.Empty;

        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public int[] Term_Id { get; set; }=[];
        public ICollection<TermModel> Terms { get; set; } = [];
    // Other properties...
}


        public class DeleteObjCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
        public class GetAllObjQuery : IRequest<IEnumerable<ObjectiveModel>>
    {
}

    public class GetObjByTermIdQuery : IRequest<IEnumerable<ObjectiveModel>>
    {
        public int Id { get; }

        public GetObjByTermIdQuery(int id)
        {
            Id = id;
        }
    }
}