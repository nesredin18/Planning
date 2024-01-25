using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity.Objectives;


namespace Todo.core.usecases.progressuse
{
    public class ProgressUse
    {
        
    }

    public class CreateP:IRequest<int>
    {

        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Done_date { get; set; }
        public string Result { get; set; }=string.Empty;
        public ActivityModel? Activity {get;set;}
        
    
    }
    public class CreateOP:IRequest<int>
    {

        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Done_date { get; set; }
        public string Result { get; set; }=string.Empty;
        public ObjectiveModel? Objective { get; set; }
    
    }
    public class GetOPByIdQuery : IRequest<ObjectiveProgress>
    {
        public int Id { get; }

        public GetOPByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetAPByIdQuery : IRequest<ActivityProgress>
    {
        public int Id { get; }

        public GetAPByIdQuery(int id)
        {
            Id = id;
        }
    }
public class UpdatePCommand : IRequest<bool>

{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Done_date { get; set; }
        public string Result { get; set; }=string.Empty;
    
    // Other properties...
}
public class UpdateOPCommand : IRequest<bool>
{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Done_date { get; set; }
        public string Result { get; set; }=string.Empty;
    
    // Other properties...
}


        public class DeletePCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

            public class DeleteOPCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

        public class GetAllOPQuery : IRequest<IEnumerable<ObjectiveProgress>>
    {
}
        public class GetAllAPQuery : IRequest<IEnumerable<ActivityProgress>>
    {
}
}