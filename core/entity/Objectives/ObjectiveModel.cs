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
        public ICollection<ObjectiveProgress> ObjectiveProgress { get; set; } = [];
        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;
        public DateTime Initial_date { get; set; }=DateTime.Now;
        public DateTime Final_date { get; set; }=DateTime.Now;
    }

    public class ActivityModel{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public ICollection<ObjectiveModel> Objective { get; set; } = [];
        public bool HasSubActivities { get; set; }=false;
        public ICollection<SubActivityModel> SubActivities { get; set; }= [];
        public ICollection<ActivityProgress> ActivityProgress { get; set; }= [];
        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public DateTime Initial_date { get; set; }=DateTime.Now;
        public DateTime Final_date { get; set; }=DateTime.Now;
        public string Result { get; set; }=string.Empty;
        
    }

    public class SubActivityModel{
        public int Id {get;set;}
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Activity_id { get; set; } 
        public ActivityModel? Activity { get; set; }
        public string Status { get; set; }=string.Empty;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;
        public DateTime Initial_date { get; set; }=DateTime.Now;
        public DateTime Final_date { get; set; } =DateTime.Now;

    }

    public class TermModel{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Initial_date { get; set; }=DateTime.Now;
        public DateTime Final_date { get; set; }=DateTime.Now;
        public string Goal { get; set; }=string.Empty;
        public string Result { get; set; }=string.Empty;

        public string Status { get; set; }=string.Empty;

        public ICollection<ObjectiveModel> Objective { get; set; } =[];
        public int Weight { get; set; }=1;
    }
    public class ObjectiveProgress{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Objective_id { get; set; }
        public DateTime Done_date { get; set; }
        public DateTime Created_date { get; set; }=DateTime.Now;
        public string Result { get; set; }=string.Empty;
        public ObjectiveModel? Objective { get; set; }
    }
        public class ActivityProgress{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Activity_id { get; set; }
        public DateTime Done_date { get; set; }
        public DateTime Created_date { get; set; }=DateTime.Now;
        public string Result { get; set; }=string.Empty;
        public ActivityModel? Activity { get; set; }
    }
}