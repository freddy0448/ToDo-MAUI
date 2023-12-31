﻿using SQLite;
using ToDo_MAUI.Model;

namespace ToDo_MAUI.Services
{
    public class TaskService : ITaskService
    {
        static SQLiteAsyncConnection db;

        private async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TaskDB.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<TaskModel>();
        }

        public async Task<int> AddTaskAsync(TaskModel taskModel)
        {
            await Init();

            return await db.InsertAsync(taskModel);
        }

        public async Task<List<TaskModel>> GetAllTaskAsync()
        {
            await Init();

            var tasksList = await db.Table<TaskModel>().ToListAsync();
            return tasksList;
        }


        public async Task<int> DeleteTaskAsync(TaskModel taskModel)
        {
            await Init();

            return await db.DeleteAsync(taskModel);
        }

        public async Task<int> UpdateTaskAsync(TaskModel taskModel)
        {
            await Init();

            return await db.UpdateAsync(taskModel);
        }

    }
};