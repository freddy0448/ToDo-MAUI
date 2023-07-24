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
            this.taskService  = taskService;
        }

        [RelayCommand]
        async void AddTask()
        {
            //await taskService.AddTaskAsync();

            var response = await taskService.AddTaskAsync(new TaskModel
            {
                Task = TaskInput
                
            });

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
        async void GetTask()
        {

        }

        [RelayCommand]
        async void SaveTask()
        {

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
