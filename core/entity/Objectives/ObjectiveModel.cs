using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.core.entity.user;

namespace Todo.core.entity.Objectives
{
    public class ObjectiveModel
    {
        public int Id { get; set; }
        public string Ob_Name { get; set; }=string.Empty;

        public string Ob_Description { get; set; }=string.Empty;
        public ICollection<ApplicationUser> AppUsers { get; set; } = [];
        public ICollection<ActivityModel> Activities { get; set; } = [];
        public ICollection<TermModel> Terms { get; set; } = [];
    }

    public class ActivityModel{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public ICollection<ObjectiveModel> Objective { get; set; } = [];
        public bool HasSubActivities { get; set; }
        public ICollection<SubActivityModel> SubActivities { get; set; }= [];
    }

    public class SubActivityModel{
        public int Id {get;set;}
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Activity_id { get; set; } 
        public ActivityModel Activity { get; set; }= new ActivityModel();

    }

    public class TermModel{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime initial_date { get; set; }
        public DateTime final_date { get; set; }
        public string goal { get; set; }=string.Empty;
        public string result { get; set; }=string.Empty;

        public string status { get; set; }=string.Empty;
        public ObjectiveModel Objective { get; set; }= new ObjectiveModel();
    }
}