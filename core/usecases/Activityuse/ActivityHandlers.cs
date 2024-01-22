using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity;
using MediatR;
using System.Diagnostics;
using Todo.core.entity.Objectives;

namespace Todo.core.usecases.Activityuse
{
    public class ActivityHandlers
    {
        
    }

     public class CreateActCommandHandler : IRequestHandler<CreateAct, int>
{
    private readonly IActRepository _actRepository;

    public CreateActCommandHandler(IActRepository actRepository)
    {
        _actRepository = actRepository;
    }

  public async Task<int> Handle(CreateAct request, CancellationToken cancellationToken)
{
    var ActItem = new ActivityModel
    {

        Name=request.Name,
        Description=request.Description,
        Status=request.Status,
        Goal=request.Goal,
        Initial_date=request.Initial_date,
        Final_date=request.Final_date,
        Result=request.Result
        

        // Set other properties if there are any
    };


    return await _actRepository.AddAct(ActItem);
}
}

 public class GetAllActQueryHandler : IRequestHandler<GetAllActQuery, IEnumerable<ActivityModel>>
    {
        private readonly IActRepository _objRepository;

        public GetAllActQueryHandler(IActRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<IEnumerable<ActivityModel>> Handle(GetAllActQuery request, CancellationToken cancellationToken)
        {
            // Assuming GetAllTasks is a method in ITaskRepository that retrieves all tasks
            return await _objRepository.GetAllAct();
        }
    }

     public class GetActByIdQueryHandler : IRequestHandler<GetActByIdQuery, ActivityModel>
    {
        private readonly IActRepository _objRepository;

        public GetActByIdQueryHandler(IActRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<ActivityModel> Handle(GetActByIdQuery request, CancellationToken cancellationToken)
        {
            return await _objRepository.GetActById(request.Id);
        }
    }

    

    public class DeleteActCommandHandler : IRequestHandler<DeleteActCommand, bool>
    {
        private readonly IActRepository _taskRepository;

        public DeleteActCommandHandler(IActRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<bool> Handle(DeleteActCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetActById(request.Id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteAct(task);
            return true;
        }
    }

        public class UpdateActCommandHandler : IRequestHandler<UpdateActCommand, bool>
    {
        private readonly IActRepository _taskRepository;

        public UpdateActCommandHandler(IActRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdateActCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task, update properties, and save changes
            var task = await _taskRepository.GetActById(request.Id);
            if (task == null)
            {
                return false;
            }
            task.Name=request.Name;
            task.Description=request.Description;
            task.Status=request.Status;
            task.Goal=request.Goal;
            task.Initial_date=request.Initial_date;
            task.Final_date=request.Final_date;
            task.Result=request.Result;

            // Update other properties as necessary

            await _taskRepository.UpdateAct(task);
            return true;
        }
    }
}