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
        bool refresh;

        [ObservableProperty]
        bool gridVisible;

        [ObservableProperty]
        ObservableCollection<TaskModel>? tasks;

        [ObservableProperty]
        TaskModel? tasks2;

        [ObservableProperty]
        string taskInput;

        public MainViewModel(ITaskService taskService)
        {
            tasks = new ObservableCollection<TaskModel>();
            tasks2 = new TaskModel();
            this.taskService = taskService;
            GridVisible = true;
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

            Tasks2.Task = TaskInput;
            Tasks.Add(taskOutput);
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
            Refresh = true;
           
            var taskResult = await taskService.GetAllTasksAsync();
            if (taskResult.Count > 0)
            {
                Tasks.Clear();

                //for (int i = 0; i < taskResult.Count; i++)
                //{
                //    taskModel2 = taskResult.Cast<ObservableCollection<string>>().ElementAt(i);

                //    taskResult[i] = (TaskModel)taskResult[i];
                //    Tasks.Add(taskModel2.ToString());
                //}

                foreach (var item in taskResult)
                {
                    Tasks.Add(item);
                }
            }

            Refresh = false;
        }

        [RelayCommand]
        async void DeleteTask(TaskModel taskModel)
        {
            var response = await taskService.DeleteTaskAsync(taskModel);
            GridVisible = false;
        }

    }
}