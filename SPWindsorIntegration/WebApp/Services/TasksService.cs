using System;
using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Services
{
    public class TasksService : ITasksService
    {
        public List<Task> GetRecentTasks(int count)
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < count; i++)
            {
                tasks.Add(new Task
                {
                    Name = "Task " + i.ToString(),
                    StartDate = DateTime.UtcNow.AddMinutes(i),
                    DueDate = DateTime.UtcNow.AddDays(1).AddMinutes(i)
                });
            }

            return tasks;
        }
    }
}