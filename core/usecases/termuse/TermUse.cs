using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity.Objectives;

namespace Todo.core.usecases.termuse
{
public class CreateTerm:IRequest<int>
    {

        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;

        public string Status { get; set; }=string.Empty;

        public ICollection<TermModel> Objective { get; set; } = [];
    
    }
    public class GetTermByIdQuery : IRequest<TermModel>
    {
        public int Id { get; }

        public GetTermByIdQuery(int id)
        {
            Id = id;
        }
    }
public class UpdateTermCommand : IRequest<bool>
{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;

        public string Status { get; set; }=string.Empty;

        public ICollection<ObjectiveModel> Objective { get; set; } = [];
    // Other properties...
}


        public class DeleteTermCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
        public class GetAllTermQuery : IRequest<IEnumerable<TermModel>>
    {
}
}