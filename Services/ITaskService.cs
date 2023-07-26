using ToDo_MAUI.Model;

namespace ToDo_MAUI.Services
{
    public interface ITaskService
    {
        Task<int> AddTaskAsync(TaskModel taskModel);
        Task<List<TaskModel>> GetAllTasksAsync();
        Task<int> DeleteTaskAsync(TaskModel taskModel);
    }
}
