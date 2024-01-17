using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace Todo.Interface.dto
{
    public class SeeDto
    {
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
    }
}