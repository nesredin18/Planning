using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.core.entity;
using Todo.core.entity.task;

namespace Todo.core.usecases.taskuse
{
    public class TaskHandlers
    {
        
    }

   public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

  public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
{
    var taskItem = new TaskModel
    {
        Title = request.Title,
        Description = request.Description
        // Set other properties if there are any
    };

    return await _taskRepository.AddTask(taskItem);
}
}

    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskModel>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskModel>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            // Assuming GetAllTasks is a method in ITaskRepository that retrieves all tasks
            return await _taskRepository.GetAllTasks();
        }
    }

     public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskModel>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetTaskById(request.Id);
        }
    }

    

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskById(request.Id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteTask(task);
            return true;
        }
    }

        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task, update properties, and save changes
            var task = await _taskRepository.GetTaskById(request.Id);
            if (task == null)
            {
                return false;
            }

            task.Title = request.Title;
            task.Description = request.Description;
            // Update other properties as necessary

            await _taskRepository.UpdateTask(task);
            return true;
        }
    }

}