using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using NUnit.Framework;
using TaskManager.Entities;
using TaskManager.API;
using TaskManager;
using TaskManager.API.Controllers;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace TaskManager.Test
{
    [TestFixture]
    public class TestService
    {
        [Test]
        public void getall_Service()
        {
            var contollerObj = new TaskController();
            IHttpActionResult response = contollerObj.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Entities.Task>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.Greater(contentResult.Content.Count, 0);
        }
        [Test]
        public async System.Threading.Tasks.Task GetTaskByIdSuccess()
        {
            var contollerObj = new TaskController();
            IHttpActionResult response = contollerObj.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Entities.Task>>;
            IHttpActionResult response1 = await contollerObj.Get(contentResult.Content[0].TaskId);
            var contentResult1 = response1 as OkNegotiatedContentResult<Entities.Task>;
            Assert.IsNotNull(contentResult1);
            Assert.IsNotNull(contentResult1.Content);
            Assert.AreEqual(contentResult.Content[0].TaskId, contentResult1.Content.TaskId);
        }
        [Test]
        public async System.Threading.Tasks.Task GetTaskByIdNotFound()
        {
            var contollerObj = new TaskController();
            IHttpActionResult response1 = await contollerObj.Get(908);
            Assert.IsInstanceOf<NotFoundResult>(response1);
        }
        [Test]
        public async System.Threading.Tasks.Task AddTask()
        {
            var contollerObj = new TaskController();
            Entities.Task tsk = new Entities.Task {TaskName = "Coding", ParentTaskName = "Programming", Priority = 5, IsTaskEnded = false, SDate = DateTime.Now, EDate = DateTime.Now.AddDays(2) };
            IHttpActionResult response = await contollerObj.Post(tsk);
            var createdResult = response as OkNegotiatedContentResult<string>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("Task Added Successfully", createdResult.Content);            

        }
        [Test]
        public async System.Threading.Tasks.Task UpdateTask()
        {
            var contollerObj = new TaskController();
            IHttpActionResult response = contollerObj.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Entities.Task>>;
            Entities.Task tsk = new Entities.Task {TaskId= contentResult.Content[0].TaskId, TaskName = "Design", ParentTaskName = "Design Program", Priority = 2, IsTaskEnded = false, SDate = DateTime.Now, EDate = DateTime.Now.AddDays(2) };
            IHttpActionResult response1 = await contollerObj.Put(contentResult.Content[0].TaskId,tsk);
            var updatedResult = response1 as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(updatedResult);
            Assert.AreEqual("Task Updated Successfully", updatedResult.Content);
        }
        [Test]
        public async System.Threading.Tasks.Task DeleteTask()
        {
            var contollerObj = new TaskController();
            IHttpActionResult response = contollerObj.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Entities.Task>>;            
            IHttpActionResult response1 = await contollerObj.Delete(contentResult.Content[0].TaskId);
            var deletedResult = response1 as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(deletedResult);
            Assert.AreEqual("Task Deleted Successfully", deletedResult.Content);
        }
        [Test]
        public async System.Threading.Tasks.Task EndTask()
        {
            var contollerObj = new TaskController();
            IHttpActionResult response = contollerObj.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Entities.Task>>;
            IHttpActionResult response1 = await contollerObj.EndTask(contentResult.Content[0].TaskId);
            var endResult = response1 as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(endResult);
            Assert.AreEqual("Task Ended Successfully", endResult.Content);
        }

    }
}
