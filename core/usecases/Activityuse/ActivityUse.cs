using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity.Objectives;

namespace Todo.core.usecases.Activityuse
{
    public class ActivityUse
    {
        
    }

    public class CreateAct:IRequest<int>
    {
        public string Name { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public string Description { get; set; }=string.Empty;
        public ICollection<ObjectiveModel> Objective { get; set; } = [];
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;

    
    }
    public class GetActByIdQuery : IRequest<ActivityModel>
    {
        public int Id { get; }

        public GetActByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetActByObjIdQuery : IRequest<IEnumerable<ActivityModel>>
    {
        public int Id { get; }

        public GetActByObjIdQuery(int id)
        {
            Id = id;
        }
    }

public class UpdateActCommand : IRequest<bool>
{
       public int Id { get; set; }  // Include the ID
        public string Name { get; set; }=string.Empty;

        public string Description { get; set; }=string.Empty;

        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
    // Other properties...
}


        public class DeleteActCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
        public class GetAllActQuery : IRequest<IEnumerable<ActivityModel>>
    {
}
}