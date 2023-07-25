using ToDo_MAUI.Services;
using ToDo_MAUI.ViewModels;

namespace ToDo_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            BindingContext = mainViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetTaskCommand.Execute(null);
        }
    }
}