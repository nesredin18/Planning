using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.Objectives;

namespace Todo.core.entity
{
    public interface ITermRepository
    {
    Task<int> AddTerm(TermModel task);
    Task<IEnumerable<TermModel>> GetAllTerms();
    Task<TermModel> GetTermById(int id);
    Task UpdateTerm(TermModel task);
    Task DeleteTerm(TermModel task);
    }
}