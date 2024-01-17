using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.core.entity.task;
using Todo.core.entity.Objectives;
using Todo.core.entity.user;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Todo.Infrastructure
{
public class ApplicationDBcontext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
        : base(options)
    {
    }
        public DbSet<TaskModel> Tasks{get; set;}
        public DbSet<ObjectiveModel> Objectives{get; set;}
        public DbSet<ActivityModel> Activities{get; set;}
        public DbSet<SubActivityModel> SubActivities{get; set;}
        public DbSet<TermModel> Terms{get; set;}



    }
}
