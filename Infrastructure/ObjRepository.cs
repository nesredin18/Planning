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

     public async Task<IEnumerable<ObjectiveModel>> GetAllObj()
    {
        return await _context.Objectives.ToListAsync();
    }

   public async Task<ObjectiveModel> GetObjById(int id)
    {
       
        var n= await _context.Objectives.FindAsync(id);
        if (n == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }
        return n;
    }
        public async Task UpdateObj(ObjectiveModel task)
    {
        // Logic to update the task in the database
        _context.Objectives.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteObj(ObjectiveModel task)
    {
        // Logic to delete the task from the database
        _context.Objectives.Remove(task);
        await _context.SaveChangesAsync();
    }
public async Task<IEnumerable<ObjectiveModel>> GetObjByEmail(ApplicationUser user)
{
    var objectives = await _context.Objectives
                                   .Where(o => o.AppUsers.Any(au => au.Id == user.Id))
                                   .ToListAsync();

    if (objectives.Count == 0)
    {
        throw new KeyNotFoundException($"You don't have any objectives.");
    }

    return objectives;
}

}
}