using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using Todo.core.entity.task;
namespace Todo.core.usecases.taskuse
{

    public class CreateTaskCommand : IRequest<int> // Returns the Id of the created task
{
    public string Title { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
}

    public class GetAllTasksQuery : IRequest<IEnumerable<TaskModel>>
    {
}

    public class GetTaskByIdQuery : IRequest<TaskModel>
    {
        public int Id { get; }

        public GetTaskByIdQuery(int id)
        {
            Id = id;
        }
    }
public class UpdateTaskCommand : IRequest<bool>
{
    public int Id { get; set; }  // Include the ID
    public string Title { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
    // Other properties...
}


        public class DeleteTaskCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
