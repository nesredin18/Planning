
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;
using Todo.core.entity.task;
using Todo.Interface.dto;

namespace Todo.Interface.mappers
{
    public static class SeeDtoM
    {
        public static SeeDto SeeDtoMapper(this TaskModel task){

            return new SeeDto
            {
                Title = task.Title,
                Description = task.Description
            };

        }
        
    }
}