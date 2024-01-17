using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.task;
using Todo.core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;



namespace Todo.Infrastructure
{
public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDBcontext _context;

    public TaskRepository(ApplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<int> AddTask(TaskModel task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

   public async Task<TaskModel> GetTaskById(int id)
    {
       
        var n= await _context.Tasks.FindAsync(id);
        if (n == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }
        return n;
    }
        public async Task UpdateTask(TaskModel task)
    {
        // Logic to update the task in the database
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteTask(TaskModel task)
    {
        // Logic to delete the task from the database
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }

    // Implement other methods
}

}