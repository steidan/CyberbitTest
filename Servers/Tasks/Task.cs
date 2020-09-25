using System;
namespace Tasks
{
    public class Task
    {
        public string Name { get; set; } // It's the identifier due to the test requirements.
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        /// <summary>==UserName</summary>
        public string Owner { get; set; }
    }
}