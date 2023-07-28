using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDo_MAUI.Model;
using ToDo_MAUI.Services;

namespace ToDo_MAUI.ViewModels
{
    [QueryProperty(nameof(TaskData), "TaskData")]
    public partial class EditViewModel : ObservableObject
    {
        private readonly ITaskService taskService;

        [ObservableProperty]
        public TaskModel taskData;

        public EditViewModel(ITaskService taskService) 
        {
            this.taskService = taskService;
            taskData = new TaskModel();
        }

        [RelayCommand]
        async void UpdateTask()
        {
            if (TaskData.Id > 0)
            {
                int response = await taskService.UpdateTaskAsync(TaskData);

                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Actualización de Tarea", "La tarea fue actualizada con éxito", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Actualización de Tarea", "La tarea no pudo ser actualizada", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Actualización de Tarea", "No se detectó ninguna tarea", "OK");
            }

        }

    }
}
