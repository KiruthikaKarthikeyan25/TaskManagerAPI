using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskManager.BusinessLib;
using TaskManager.Entities;
using System.Threading;

namespace TaskManager.Test
{
   [TestFixture]
    public class TestBAL
    {
        [Test]
        public void GetAll()
        {
            TaskBL obj = new TaskBL();
            int count = obj.GetAll().Count();
            Assert.Greater(count, 0);
        }
        [Test]
        public async System.Threading.Tasks.Task GetTaskById()
        {
            TaskBL obj = new TaskBL();
            List<Task> Ts = obj.GetAll();           
            var tasks = await obj.GetById(Ts[0].TaskId);
            Assert.IsNotNull(tasks);            

        }
        [Test]
        public async System.Threading.Tasks.Task AddTask()
        {
            TaskBL obj = new TaskBL();
            int count = obj.GetAll().Count();
            Task  tsk = new Task { TaskName = "Test Task", ParentTaskName = "Test Parent Task", Priority = 2, IsTaskEnded = false, SDate = DateTime.Now, EDate = DateTime.Now.AddDays(2) };
            await obj.Add(tsk);
            int count1 = obj.GetAll().Count();
            Assert.AreEqual(count+1,count1);
        }
        [Test]
        public async System.Threading.Tasks.Task UpdateTask()
        {
            TaskBL obj = new TaskBL();
            List<Task> Ts = obj.GetAll();
            var tasks = await obj.GetById(Ts[0].TaskId);            
            Task tsk = new Task {TaskId = tasks.TaskId, TaskName = "New Test Task", ParentTaskName = "New Test Parent Task", Priority = 5, IsTaskEnded = false, SDate = DateTime.Now, EDate = DateTime.Now.AddDays(2) };
            await obj.UpdateTask(tsk);
            //int count1 = obj.GetAll().Count();
            string tskName = "New Test Task";
             Assert.AreEqual(tskName,tsk.TaskName);
        }
        [Test]
        public async System.Threading.Tasks.Task DeleteTask()
        {
            TaskBL obj = new TaskBL();
            List<Task> Ts = obj.GetAll();
            int count = obj.GetAll().Count();
            var tasks = await obj.GetById(Ts[0].TaskId);            
            await obj.DeleteTask(tasks.TaskId);
            int count1 = obj.GetAll().Count();
            Assert.AreEqual(count-1, count1);
        }




    }
}
