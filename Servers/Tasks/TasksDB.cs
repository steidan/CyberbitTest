using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Tasks.DAL;
using System.Threading;

namespace Tasks // Idealy I will pick a different name to the task so it doesn't collide with threading "Task".
{
    // I'm aware that implementing the DAL is incorrect. Doing so because creating
    // a thin DAL to this entity seems to be redundant and duck typing doesn't exist in the type system.
    internal class TasksDB : ITasksDBDAL
    {
        private List<Task> Tasks { get; set; }
        public TasksDB(
            IEnumerable<Task> tasks
        )
        {
            this.Tasks = tasks.ToList(); // accept as many param types as possible and return the data with a type that reflects what's under it, the most.
        }
        public Task<List<Task>> GetUserTasks(string userName)
        {
            return System.Threading.Tasks.Task.Run<List<Task>>(() =>
            {
                var userTasks = new List<Task>();
                foreach (var task in this.Tasks)
                {
                    if (task.Owner == userName)
                    {
                        userTasks.Add(task);
                    }
                }

                if (userTasks.Count == 0)
                {
                    return null;
                }
                return userTasks;
            });
        }

        public System.Threading.Tasks.Task Create(Task task)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                if (!Tasks.Exists((t) => t.Name == task.Name))
                {
                    this.Tasks.Add(task);
                    return;
                }
                throw new Exception("It's impossible to create a task with the same name of an already existing one");
            });
        }

        public System.Threading.Tasks.Task MarkAsDone(string taskName)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {

                foreach (var task in this.Tasks)
                {
                    if (task.Name == taskName)
                    {
                        if (task.IsDone)
                        {
                            throw new Exception("It's impossible to remark a task as done");
                        }
                        else
                        {
                            task.IsDone = true;
                            return;
                        }
                    }
                }

                throw new Exception("It's impossible to mark as done a task that doesn't exist");
            });
        }
    }
}