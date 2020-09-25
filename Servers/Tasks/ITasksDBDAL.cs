using System.Collections.Generic;
using System.Threading.Tasks;
namespace Tasks
{
    public interface ITasksDBDAL
    {
        Task<List<Task>> GetUserTasks(string userName);
        /// <summary>
        /// Throws exception when there's an existing task with the same name.
        /// </summary>
        System.Threading.Tasks.Task Create(Task task);
        /// <summary>
        /// Throws exception when there's no task with the given name, or there is one, but it's already marked as done.
        /// </summary>
        System.Threading.Tasks.Task MarkAsDone(string taskName);
    }
}