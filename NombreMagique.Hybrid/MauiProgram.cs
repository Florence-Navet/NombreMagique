using Microsoft.Extensions.Logging;


namespace NombreMagique.Hybrid
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
                });

            builder.Services.AddMauiBlazorWebView();
            Uri baseAddress;
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                // Android Emulator : 10.0.2.2 correspond à localhost du PC
                baseAddress = new Uri("http://10.0.2.2:5254/");
            }
            else
            {
                // iOS Simulator, Mac ou Windows : localhost fonctionne
                baseAddress = new Uri("http://localhost:5254/");
            }

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
