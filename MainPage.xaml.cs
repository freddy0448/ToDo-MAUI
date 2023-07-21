using ToDo_MAUI.ViewModels;

namespace ToDo_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }

    }
}