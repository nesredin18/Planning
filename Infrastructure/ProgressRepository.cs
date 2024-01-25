using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.core.entity;
using Todo.core.entity.Objectives;

namespace Todo.Infrastructure
{
   public class ProgressRepository : IProgressRepository
{
    private readonly ApplicationDBcontext _context;

    public ProgressRepository(ApplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<int> AddOP(ObjectiveProgress task)
    {   
        _context.ObjectiveProgress.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }

        public async Task<IEnumerable<ObjectiveProgress>> GetAllOP()
    {
        return await _context.ObjectiveProgress.ToListAsync();
    }

   public async Task<ObjectiveProgress> GetOPById(int id)
    {
       
        var n= await _context.ObjectiveProgress.FindAsync(id);
        if (n == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }
        return n;
    }
        public async Task UpdateOP(ObjectiveProgress task)
    {
        // Logic to update the task in the database
        _context.ObjectiveProgress.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteOP(ObjectiveProgress task)
    {
        // Logic to delete the task from the database
        _context.ObjectiveProgress.Remove(task);
        await _context.SaveChangesAsync();
    }

        public async Task<int> AddAP(ActivityProgress task)
    {
        _context.ActivityProgress.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }

        public async Task<IEnumerable<ActivityProgress>> GetAllAP()
    {
        return await _context.ActivityProgress.ToListAsync();
    }

   public async Task<ActivityProgress> GetAPById(int id)
    {
       
        var n= await _context.ActivityProgress.FindAsync(id);
        if (n == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }
        return n;
    }
        public async Task UpdateAP(ActivityProgress task)
    {
        // Logic to update the task in the database
        _context.ActivityProgress.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAP(ActivityProgress task)
    {
        // Logic to delete the task from the database
        _context.ActivityProgress.Remove(task);
        await _context.SaveChangesAsync();
    }

    // Implement other methods
}
}