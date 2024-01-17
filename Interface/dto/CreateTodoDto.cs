using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Interface.dto
{
    public class CreateTodoDto
    {
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;

    }
}