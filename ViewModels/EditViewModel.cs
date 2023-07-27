using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDo_MAUI.Model;
using ToDo_MAUI.Services;

namespace ToDo_MAUI.ViewModels
{
    //[QueryProperty nameof(taskData), "taskData" ]
    public partial class EditViewModel : ObservableObject
    {
        ITaskService taskService;
        public EditViewModel(ITaskService taskService) 
        {
            this.taskService = taskService;
        }
        [ObservableProperty]
        private TaskModel taskData;

        [RelayCommand]
        async void UpdateTask()
        {

        }

    }
}
