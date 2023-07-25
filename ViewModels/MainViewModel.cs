using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDo_MAUI.Model;
using ToDo_MAUI.Services;

namespace ToDo_MAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        ITaskService taskService;

        [ObservableProperty]
        ObservableCollection<string> tasks;

        [ObservableProperty]
        string taskInput;

        [ObservableProperty]
        string savingTasks;

        [ObservableProperty]
        string savedTasks;


        public MainViewModel(ITaskService taskService)
        {
            tasks = new ObservableCollection<string>();
            this.taskService = taskService;
        }

        [RelayCommand]
        async void AddSaveTask()
        {
            //await taskService.AddTaskAsync();
            if (string.IsNullOrEmpty(TaskInput)) return;

            var response = await taskService.AddTaskAsync(new TaskModel
            {
                Task = TaskInput
            });

            Tasks.Add(TaskInput);
            TaskInput = string.Empty;

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Registro de Tareas", "Tarea registrada con éxito", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Registro de Tareas", "Fallo en el registro de la tarea", "OK");
            }
        }

        [RelayCommand]
        public async void GetTask()
        {
            var taskResult = await taskService.GetAllTasksAsync();

            if (taskResult.Count > 0)
            {
                Tasks.Clear();
                foreach (var item in taskResult)
                {
                    Tasks.Add(item.Task);
                }
            }
        }

        [RelayCommand]
        async void DeleteTask()
        {

        }

        [RelayCommand]
        void GetId(TaskModel taskModel)
        {
            if (taskModel == null) return;

            //var rout = $"{}";
        }
    }
}
