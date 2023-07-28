using ToDo_MAUI.Model;

namespace ToDo_MAUI.Services
{
    public interface ITaskService
    {
        Task<int> AddTaskAsync(TaskModel taskModel);
        Task<List<TaskModel>> GetAllTaskAsync();
        Task<int> DeleteTaskAsync(TaskModel taskModel);

        Task<int> UpdateTaskAsync(TaskModel taskModel);
    }
}
