using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataLib;
using TaskManager.Entities;


namespace TaskManager.BusinessLib
{
    public class TaskBL
    {
        public List<Entities.Task> GetAll()
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return  db.Tasks.ToList();                
            };
        }

        public async Task<string> Add(Entities.Task item)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                try
                {
                    string test = string.Empty;
                    db.Tasks.Add(item);
                    await db.SaveChangesAsync();
                    return "Task added successfully";
                }
                catch(Exception ex)
                {
                    return "Error adding the task";
                }
            };
        }

        public async Task<Entities.Task> GetById(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                //return db.Tasks.SingleOrDefault(k => k.TaskId == id);
                return await db.Tasks.FindAsync(id);
            };
        }

        public async Task<string> DeleteTask(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                //var TaskResult;
                
                
                    var TaskResult = db.Tasks.Where(k => k.TaskId == id).FirstOrDefault();
                    if (TaskResult == null)
                        return "Task Not Found";
                    db.Tasks.Remove(TaskResult);
                    await db.SaveChangesAsync();
                    return "Task Deleted Successfully";
                
                
            };
        }
        public async Task<string> UpdateTask(Entities.Task Tsk)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var TaskResult = db.Tasks.Where(k => k.TaskId == Tsk.TaskId).FirstOrDefault();
                if (TaskResult == null)
                    return "Task Not Found";
                TaskResult.TaskName = Tsk.TaskName;
                TaskResult.ParentTaskName = Tsk.ParentTaskName;
                TaskResult.Priority = Tsk.Priority;
                TaskResult.SDate = Tsk.SDate;
                TaskResult.EDate = Tsk.EDate;
                await db.SaveChangesAsync();
                return "Task Updated Successfully";
                              
            };
        }
        //public Entities.Task EditTask(int Id)
        //{
        //    using (TaskManagerContext db = new TaskManagerContext())
        //    {
        //        var TaskResult = db.Tasks.Where(k => k.TaskId == Id).FirstOrDefault();
        //        if (TaskResult != null)
        //            return TaskResult;
        //        else
        //            return null;
        //    };
        //}
        public async Task<string> EndTask(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var TaskResult = db.Tasks.Where(k => k.TaskId == id).FirstOrDefault();
                if (TaskResult == null)
                    return "Task Not Found";
                TaskResult.EDate = DateTime.Now;
                TaskResult.IsTaskEnded = true;
               await db.SaveChangesAsync();
                return "Task Ended Successfully";
            };
        }
    }
}
