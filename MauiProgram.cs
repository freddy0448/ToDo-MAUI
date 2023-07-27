using Microsoft.Extensions.Logging;
using ToDo_MAUI.Services;
using ToDo_MAUI.ViewModels;
using ToDo_MAUI.Views;

namespace ToDo_MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ITaskService, TaskService>();
            
            builder.Services.AddTransient<EditViewModel>();
            builder.Services.AddTransient<EditPage>();

#endif

            return builder.Build();
        }
    }
}