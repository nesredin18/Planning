using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Todo.core.usecases.ObjectiveUse;
using Todo.core.entity;
using Todo.core.entity.Objectives;
using MediatR;


namespace Todo.core.usecases.ObjectiveUse
{
    public class ObjectiveHandler
    {
        
    }

    public class CreateObjectiveCommandHandler : IRequestHandler<CreateObjective, int>
{
    private readonly IObjRepository _objRepository;

    public CreateObjectiveCommandHandler(IObjRepository objRepository)
    {
        _objRepository = objRepository;
    }

  public async Task<int> Handle(CreateObjective request, CancellationToken cancellationToken)
{
    var ObjectItem = new ObjectiveModel
    {

        Ob_Name=request.Ob_Name,
        Ob_Description=request.Ob_Description,
        Status=request.Status,
        Goal=request.Goal,
        Initial_date=request.Initial_date,
        Final_date=request.Final_date,
        Result=request.Result
        

        // Set other properties if there are any
    };

    return await _objRepository.AddObj(ObjectItem);
}
}

 public class GetAllObjQueryHandler : IRequestHandler<GetAllObjQuery, IEnumerable<ObjectiveModel>>
    {
        private readonly IObjRepository _objRepository;

        public GetAllObjQueryHandler(IObjRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<IEnumerable<ObjectiveModel>> Handle(GetAllObjQuery request, CancellationToken cancellationToken)
        {
            // Assuming GetAllTasks is a method in ITaskRepository that retrieves all tasks
            return await _objRepository.GetAllObj();
        }
    }

     public class GetObjByIdQueryHandler : IRequestHandler<GetObjByIdQuery, ObjectiveModel>
    {
        private readonly IObjRepository _objRepository;

        public GetObjByIdQueryHandler(IObjRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<ObjectiveModel> Handle(GetObjByIdQuery request, CancellationToken cancellationToken)
        {
            return await _objRepository.GetObjById(request.Id);
        }
    }

    

    public class DeleteObjCommandHandler : IRequestHandler<DeleteObjCommand, bool>
    {
        private readonly IObjRepository _taskRepository;

        public DeleteObjCommandHandler(IObjRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<bool> Handle(DeleteObjCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetObjById(request.Id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteObj(task);
            return true;
        }
    }

        public class UpdateObjCommandHandler : IRequestHandler<UpdateObjCommand, bool>
    {
        private readonly IObjRepository _taskRepository;

        public UpdateObjCommandHandler(IObjRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdateObjCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task, update properties, and save changes
            var task = await _taskRepository.GetObjById(request.Id);
            if (task == null)
            {
                return false;
            }
            task.Ob_Name=request.Ob_Name;
            task.Ob_Description=request.Ob_Description;
            task.Status=request.Status;
            task.Goal=request.Goal;
            task.Initial_date=request.Initial_date;
            task.Final_date=request.Final_date;
            task.Result=request.Result;

            // Update other properties as necessary

            await _taskRepository.UpdateObj(task);
            return true;
        }
    }
}