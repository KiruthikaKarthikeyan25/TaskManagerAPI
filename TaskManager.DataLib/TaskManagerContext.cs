using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using System.Data.Entity;

namespace TaskManager.DataLib
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext():base("TaskMgrConnection")
        {

        }
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
