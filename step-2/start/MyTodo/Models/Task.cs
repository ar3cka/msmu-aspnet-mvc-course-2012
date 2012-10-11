using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTodo.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }        
    }
}