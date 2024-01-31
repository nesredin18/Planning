using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo.core.entity;
using Todo.core.entity.Objectives;

namespace Todo.core.usecases.termuse
{
    public class TermHandlers
    {
        
    }
    public class CreateTermCommandHandler : IRequestHandler<CreateTerm, int>
{
    private readonly ITermRepository _objRepository;

    public CreateTermCommandHandler(ITermRepository objRepository)
    {
        _objRepository = objRepository;
    }

  public async Task<int> Handle(CreateTerm request, CancellationToken cancellationToken)
{
    var ObjectItem = new TermModel
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

    return await _objRepository.AddTerm(ObjectItem);
}
}

 public class GetAllTermQueryHandler : IRequestHandler<GetAllTermQuery, IEnumerable<TermModel>>
    {
        private readonly ITermRepository _objRepository;

        public GetAllTermQueryHandler(ITermRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<IEnumerable<TermModel>> Handle(GetAllTermQuery request, CancellationToken cancellationToken)
        {
            // Assuming GetAllTasks is a method in ITaskRepository that retrieves all tasks
            return await _objRepository.GetAllTerms();
        }
    }

     public class GetTermByIdQueryHandler : IRequestHandler<GetTermByIdQuery, TermModel>
    {
        private readonly ITermRepository _objRepository;

        public GetTermByIdQueryHandler(ITermRepository objRepository)
        {
            _objRepository = objRepository;
        }

        public async Task<TermModel> Handle(GetTermByIdQuery request, CancellationToken cancellationToken)
        {
            return await _objRepository.GetTermById(request.Id);
        }
    }

     public class GetTermByObjIdQueryHandler : IRequestHandler<GetTermByObjIdQuery, IEnumerable<TermModel>>
    {
        private readonly ITermRepository _objRepository;

        public GetTermByObjIdQueryHandler(ITermRepository objRepository)
        {
            _objRepository = objRepository;
        }
        

        public async Task<IEnumerable<TermModel>> Handle(GetTermByObjIdQuery request, CancellationToken cancellationToken)
        {
            return await _objRepository.GetTermByObjId(request.Id);
        }
    }

    

    public class DeleteTermCommandHandler : IRequestHandler<DeleteTermCommand, bool>
    {
        private readonly ITermRepository _taskRepository;

        public DeleteTermCommandHandler(ITermRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<bool> Handle(DeleteTermCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTermById(request.Id);
            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteTerm(task);
            return true;
        }
    }

        public class UpdateTermCommandHandler : IRequestHandler<UpdateTermCommand, bool>
    {
        private readonly ITermRepository _taskRepository;

        public UpdateTermCommandHandler(ITermRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdateTermCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task, update properties, and save changes
            var task = await _taskRepository.GetTermById(request.Id);
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

            await _taskRepository.UpdateTerm(task);
            return true;
        }
    }
}