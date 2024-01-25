using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.Objectives;

namespace Todo.core.entity
{
    public interface IProgressRepository
    {
    Task<int> AddOP(ObjectiveProgress task);
    Task<IEnumerable<ObjectiveProgress>> GetAllOP();
    Task<ObjectiveProgress> GetOPById(int id);
    Task UpdateOP(ObjectiveProgress task);
    Task DeleteOP(ObjectiveProgress task);
    Task<int> AddAP(ActivityProgress task);
    Task<IEnumerable<ActivityProgress>> GetAllAP();
    Task<ActivityProgress> GetAPById(int id);
    Task UpdateAP(ActivityProgress task);
    Task DeleteAP(ActivityProgress task);
    }
}