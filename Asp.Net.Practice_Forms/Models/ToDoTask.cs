using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Models
{
    public class ToDoTask: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
