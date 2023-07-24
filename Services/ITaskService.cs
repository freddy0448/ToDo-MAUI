using ToDo_MAUI.Model;

namespace ToDo_MAUI.Services
{
    public interface ITaskService
    {
        Task<int> AddTaskAsync(TaskModel taskModel);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task DeleteTaskAsync(int id);
    }
}
