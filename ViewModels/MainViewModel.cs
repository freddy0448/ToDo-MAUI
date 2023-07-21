using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ToDo_MAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private const string accessKey = "TasksSaved";

        [ObservableProperty]
        ObservableCollection<string> tasks;

        [ObservableProperty]
        string taskInput;

        [ObservableProperty]
        string savingTasks;

        [ObservableProperty]
        string savedTasks;
        public MainViewModel()
        {
            tasks = new ObservableCollection<string>();
        }

        [RelayCommand]
        void AddTask()
        {
            if (string.IsNullOrEmpty(taskInput))
                return;
            SavingTasks = TaskInput;

            SaveTask();
            GetTask();
            TaskInput = string.Empty;

            
            if (string.IsNullOrEmpty(SavedTasks))
                return;

            Tasks.Add(SavedTasks);
        }

        [RelayCommand]
        async void GetTask()
        {
            SavedTasks = await SecureStorage.Default.GetAsync(accessKey);
        }

        [RelayCommand]
        async void SaveTask()
        {
            await SecureStorage.Default.SetAsync(accessKey, SavingTasks);
        }

    }
}
