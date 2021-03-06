﻿using System.Collections.Generic;
using WebApp.Model;

namespace WebApp.Services
{
    public interface ITasksService
    {
        List<Task> GetRecentTasks(int count);
    }
}
