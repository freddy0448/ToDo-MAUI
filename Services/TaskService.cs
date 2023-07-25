using SQLite;
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

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            await Init();

            var tasksList = await db.Table<TaskModel>().ToListAsync();
            return tasksList;
        }


        public async Task DeleteTaskAsync(int id)
        {
            await Init();

            await db.DeleteAsync(id);
        }

    }
};