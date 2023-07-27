using ToDo_MAUI.Views;

namespace ToDo_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
        }
    }
}