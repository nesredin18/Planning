using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity;
using Todo.core.entity.Objectives;

namespace Todo.core.usecases.progressuse
{
    public class ProgressHandlers
    {
        
    }
     public class CreateOPCommandHandler : IRequestHandler<CreateOP, int>
{
    private readonly IProgressRepository _objRepository;

    public CreateOPCommandHandler(IProgressRepository objRepository)
    {
        _objRepository = objRepository;
    }

  public async Task<int> Handle(CreateOP request, CancellationToken cancellationToken)
{
    var ObjectItem = new ObjectiveProgress
    {

        Name=request.Name,
        Description=request.Description,
        Done_date=request.Done_date,
        Result=request.Result
        

        // Set other properties if there are any
    };


    return await _objRepository.AddOP(ObjectItem);
}
}

     public class CreateAPCommandHandler : IRequestHandler<CreateP, int>
{
    private readonly IProgressRepository _objRepository;

    public CreateAPCommandHandler(IProgressRepository objRepository)
    {
        _objRepository = objRepository;
    }

  public async Task<int> Handle(CreateP request, CancellationToken cancellationToken)
{
    var ObjectItem = new ActivityProgress
    {

        Name=request.Name,
        Description=request.Description,
        Done_date=request.Done_date,
        Result=request.Result
        

        // Set other properties if there are any
    };


    return await _objRepository.AddAP(ObjectItem);
}
}

 public class GetAllOPQueryHandler : IRequestHandler<GetAllOPQuery, IEnumerable<ObjectiveProgress>>
    {
        private readonly IProgressRepository _objRepository;

        public GetAllOPQueryHandler(IProgressRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<IEnumerable<ObjectiveProgress>> Handle(GetAllOPQuery request, CancellationToken cancellationToken)
        {
            // Assuming GetAllTasks is a method in ITaskRepository that retrieves all tasks
            return await _objRepository.GetAllOP();
        }
    }

 public class GetAllAPQueryHandler : IRequestHandler<GetAllAPQuery, IEnumerable<ActivityProgress>>
    {
        private readonly IProgressRepository _objRepository;

        public GetAllAPQueryHandler(IProgressRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<IEnumerable<ActivityProgress>> Handle(GetAllAPQuery request, CancellationToken cancellationToken)
        {
            // Assuming GetAllTasks is a method in ITaskRepository that retrieves all tasks
            return await _objRepository.GetAllAP();
        }
    }

     public class GetOPByIdQueryHandler : IRequestHandler<GetOPByIdQuery, ObjectiveProgress>
    {
        private readonly IProgressRepository _objRepository;

        public GetOPByIdQueryHandler(IProgressRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<ObjectiveProgress> Handle(GetOPByIdQuery request, CancellationToken cancellationToken)
        {
            return await _objRepository.GetOPById(request.Id);
        }
    }
     public class GetAPByIdQueryHandler : IRequestHandler<GetAPByIdQuery, ActivityProgress>
    {
        private readonly IProgressRepository _objRepository;

        public GetAPByIdQueryHandler(IProgressRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<ActivityProgress> Handle(GetAPByIdQuery request, CancellationToken cancellationToken)
        {
            return await _objRepository.GetAPById(request.Id);
        }
    }

    

    public class DeleteOPCommandHandler : IRequestHandler<DeleteOPCommand, bool>
    {
        private readonly IProgressRepository _taskRepository;

        public DeleteOPCommandHandler(IProgressRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<bool> Handle(DeleteOPCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetOPById(request.Id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteOP(task);
            return true;
        }
    }

    public class DeleteAPCommandHandler : IRequestHandler<DeletePCommand, bool>
    {
        private readonly IProgressRepository _taskRepository;

        public DeleteAPCommandHandler(IProgressRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<bool> Handle(DeletePCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetAPById(request.Id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteAP(task);
            return true;
        }
    }

        public class UpdateOPCommandHandler : IRequestHandler<UpdateOPCommand, bool>
    {
        private readonly IProgressRepository _taskRepository;

        public UpdateOPCommandHandler(IProgressRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdateOPCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task, update properties, and save changes
            var task = await _taskRepository.GetOPById(request.Id);
            if (task == null)
            {
                return false;
            }
            task.Name=request.Name;
            task.Description=request.Description;
            task.Done_date=request.Done_date;
            task.Result=request.Result;

            // Update other properties as necessary

            await _taskRepository.UpdateOP(task);
            return true;
        }
    }
            public class UpdateAPCommandHandler : IRequestHandler<UpdatePCommand, bool>
    {
        private readonly IProgressRepository _taskRepository;

        public UpdateAPCommandHandler(IProgressRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdatePCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task, update properties, and save changes
            var task = await _taskRepository.GetAPById(request.Id);
            if (task == null)
            {
                return false;
            }
            task.Name=request.Name;
            task.Description=request.Description;

            task.Done_date=request.Done_date;
            task.Result=request.Result;

            // Update other properties as necessary

            await _taskRepository.UpdateAP(task);
            return true;
        }
    }
}