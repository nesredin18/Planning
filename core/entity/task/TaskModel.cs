using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.core.entity.task
{
    public class TaskModel
    {
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
    public bool IsCompleted { get; set; }
    }
}