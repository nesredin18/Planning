using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.task;

namespace Todo.core.entity
{
    public interface ITaskRepository
    {
    Task<int> AddTask(TaskModel task);
    Task<IEnumerable<TaskModel>> GetAllTasks();
     Task<TaskModel> GetTaskById(int id);
    Task UpdateTask(TaskModel task);
    Task DeleteTask(TaskModel task);
    }
}