using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Entities;
using TaskManager.BusinessLib;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace TaskManager.API.Controllers
{
    public class TaskController : ApiController
    {
        TaskBL taskObj = new TaskBL();

        [Route("GetAllTask")]
        public IHttpActionResult Get()
        {
            return Ok(taskObj.GetAll());
        }

         //GET: api/Tasks/id
        [Route("GetTaskById/{id:int}")]
        [ResponseType(typeof(Entities.Task))]
        public async Task<IHttpActionResult> Get(int id)
        {
            Entities.Task task = await taskObj.GetById(id);
            if (task == null)
            {
                return this.NotFound();
            }

            return Ok(task);
        }

        [Route("UpdateTaskById/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, Entities.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }
            string result = await taskObj.UpdateTask(task);
            if (result == "Task Not Found")
                return NotFound();
            return Ok(result);

        }

        [ResponseType(typeof(Entities.Task))]
        [Route("AddTask")]
        public async Task<IHttpActionResult> Post(Entities.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            await taskObj.Add(task);
            return Ok("Task Added Successfully");             
        }
        [Route("DeleteTaskById/{id:int}")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            string result = await taskObj.DeleteTask(id);
            if (result == "Task Not Found")
                return NotFound();
            return Ok(result);

        }

        [Route("EndTaskById/{id:int}")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public async Task<IHttpActionResult> EndTask(int id)
        {
            //Entities.Task task = new Entities.Task();
            //task.TaskId = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != task.TaskId)
            //{
            //    return BadRequest();
            //}
            string result = await taskObj.EndTask(id);
            if (result == "Task Not Found")
                return NotFound();
            return Ok(result);

        }
    }
}
