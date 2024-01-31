using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.Objectives;
using Todo.core.entity.user;

namespace Todo.core.entity
{
    public interface IObjRepository
    {
    Task<int> AddObj(ObjectiveModel task);
    Task<IEnumerable<ObjectiveModel>> GetAllObj();
     Task<ObjectiveModel> GetObjById(int id);
    Task UpdateObj(ObjectiveModel obj);
    Task DeleteObj(ObjectiveModel obj);
     Task<IEnumerable<ObjectiveModel>> GetObjByEmail(ApplicationUser user);
    // Task<int> AddTermToObj(TermModel term);
     Task<IEnumerable<ObjectiveModel>> GetObjByTerm(int id);
     Task SaveDbAsync();
    }
}