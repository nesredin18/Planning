using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity;
using Todo.core.entity.Objectives;
using Todo.core.entity.user;
using Todo.core.usecases.ObjectiveUse;

namespace Todo.Infrastructure
{


    public class ObjRepository : IObjRepository
{
    private readonly ApplicationDBcontext _context;

    public ObjRepository(ApplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<int> AddObj(ObjectiveModel task)
    { 
        _context.Objectives.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }
}
}