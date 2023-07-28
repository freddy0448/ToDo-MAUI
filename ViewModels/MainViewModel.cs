using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDo_MAUI.Model;
using ToDo_MAUI.Services;
using ToDo_MAUI.Views;

namespace ToDo_MAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        readonly ITaskService taskService;

        [ObservableProperty]
        public bool refresh;

        [ObservableProperty]
        public ObservableCollection<TaskModel> tasks;

        [ObservableProperty]
        ObservableCollection<string>  titles;

        [ObservableProperty]
        TaskModel taskInput;

        public MainViewModel(ITaskService taskService)
        {
            tasks = new ObservableCollection<TaskModel>();
            titles = new ObservableCollection<string>();
            this.taskService = taskService;
        }

        [RelayCommand]
        async void AddSaveTask()
        {
            //await taskService.AddTaskAsync();
            if (string.IsNullOrEmpty(TaskInput.Task)) return;

            var response = await taskService.AddTaskAsync(new TaskModel
            {
                Task = TaskInput.Task
            });

            Tasks.Add(TaskInput);
            Titles.Add(TaskInput.Task);
            TaskInput.Task = string.Empty;

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
           
            var taskResult = await taskService.GetAllTaskAsync();
            if (taskResult.Count > 0)
            {
                Tasks.Clear();
                Titles.Clear();

                //for (int i = 0; i < taskResult.Count; i++)
                //{
                //    taskModel2 = taskResult.Cast<ObservableCollection<string>>().ElementAt(i);

                //    taskResult[i] = (TaskModel)taskResult[i];
                //    Tasks.Add(taskModel2.ToString());
                //}

                foreach (var item in taskResult)
                {
                    Tasks.Add(item);
                    Titles.Add(item.Task);
                }
            }

            Refresh = false;
        }

        [RelayCommand]
        async void DeleteTask(TaskModel taskModel)
        {
            await taskService.DeleteTaskAsync(taskModel);
        }

        [RelayCommand]
        async void EditTask(TaskModel taskModel)
        {
            var varParam = new Dictionary<string, object>();
            varParam.Add("TaskData", taskModel);
            await Shell.Current.GoToAsync(nameof(EditPage), varParam);
        }
    }
}