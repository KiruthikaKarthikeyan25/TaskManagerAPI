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
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<TaskManagerContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
