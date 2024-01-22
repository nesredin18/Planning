using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.core.entity;
using Todo.core.entity.Objectives;
using Todo.core.entity.user;
using Todo.core.usecases.ObjectiveUse;

namespace Todo.Infrastructure
{


    public class ActRepository : IActRepository
{
    private readonly ApplicationDBcontext _context;

    public ActRepository(ApplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<int> AddAct(ActivityModel task)
    { 
        _context.Activities.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }

     public async Task<IEnumerable<ActivityModel>> GetAllAct()
    {
        return await _context.Activities.ToListAsync();
    }

   public async Task<ActivityModel> GetActById(int id)
    {
       
        var n= await _context.Activities.FindAsync(id);
        if (n == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }
        return n;
    }
        public async Task UpdateAct(ActivityModel task)
    {
        // Logic to update the task in the database
        _context.Activities.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAct(ActivityModel task)
    {
        // Logic to delete the task from the database
        _context.Activities.Remove(task);
        await _context.SaveChangesAsync();
    }
public async Task<IEnumerable<ActivityModel>> GetActByObj(ObjectiveModel obj)
{
    var objectives = await _context.Activities
                                   .Where(o => o.Objective.Any(au => au.Id == obj.Id))
                                   .ToListAsync();

    if (objectives.Count == 0)
    {
        throw new KeyNotFoundException($"You don't have any objectives.");
    }

    return objectives;
}

}
}