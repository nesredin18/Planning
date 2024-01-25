using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.Objectives;
using Todo.core.entity.user;

namespace Todo.core.entity
{
    public interface IActRepository
    {
    Task<int> AddAct(ActivityModel task);
    Task<IEnumerable<ActivityModel>> GetAllAct();
     Task<ActivityModel> GetActById(int id);
    Task UpdateAct(ActivityModel obj);
    Task DeleteAct(ActivityModel obj);
     Task<IEnumerable<ActivityModel>> GetActByObjId(int id);
    }
    }
