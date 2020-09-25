using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tasks
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ITasksDBDAL TasksDBDAL { get; set; }
        public TasksController(
            ITasksDBDAL tasksDBDAL
        )
        {
            this.TasksDBDAL = tasksDBDAL;
            System.Console.WriteLine(tasksDBDAL);
        }


        [HttpGet("Owner/{userName}")]
        public async Task<List<Task>> GetUserTasks(string userName)
        {
            return await this.TasksDBDAL.GetUserTasks(userName);
        }

        [HttpPost("Create")]
        public async System.Threading.Tasks.Task Create([FromBody] Task task)
        {
            try
            {
                await this.TasksDBDAL.Create(task);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpGet("MarkAsDone/{taskName}")]
        public async System.Threading.Tasks.Task MarkAsDone(string taskName)
        {
            try
            {
                await this.TasksDBDAL.MarkAsDone(taskName);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
