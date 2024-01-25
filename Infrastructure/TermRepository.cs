using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Todo.core.entity.user;
using Todo.core.entity;
using Todo.core.entity.Objectives;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure
{
public class TermRepository : ITermRepository
{
    private readonly ApplicationDBcontext _context;

    public TermRepository(ApplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<int> AddTerm(TermModel task)
    {
        _context.Terms.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }

        public async Task<IEnumerable<TermModel>> GetAllTerms()
    {
        return await _context.Terms.ToListAsync();
    }

   public async Task<TermModel> GetTermById(int id)
    {
       
        var n= await _context.Terms.FindAsync(id);
        if (n == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }
        return n;
    }
        public async Task UpdateTerm(TermModel task)
    {
        // Logic to update the task in the database
        _context.Terms.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteTerm(TermModel task)
    {
        // Logic to delete the task from the database
        _context.Terms.Remove(task);
        await _context.SaveChangesAsync();
    }

    // Implement other methods
}
}