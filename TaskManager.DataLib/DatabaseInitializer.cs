using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TaskManager.DataLib
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<TaskManagerContext>
    {
        protected override void Seed(TaskManagerContext context)
        {
            base.Seed(context);

            /*Entities.Task Tsk = new Entities.Task
            {
                Priority = 1,
                SDate = DateTime.Now.Date,
                TaskName = "Start Project"

            };
            context.Tasks.Add(Tsk);
            Entities.Task Tsk1 = new Entities.Task
            {
                Priority = 2,
                SDate = DateTime.Now.Date,
               TaskName = "Start Project Design"

            };

            context.Tasks.Add(Tsk1);
            context.SaveChanges();*/
        }
    }
}
