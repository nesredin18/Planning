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

        // Set other properties if there are any
    };

    return await _objRepository.AddObj(ObjectItem);
}
}
}