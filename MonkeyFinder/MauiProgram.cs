﻿using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;
using MonkeyFinder.View;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder
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

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

            builder.Services.AddSingleton<MonkeyService>();

            builder.Services.AddSingleton<MonkeysViewModel>();

            // sempre que solicitado cria uma nova instância
            builder.Services.AddTransient<MonkeyDetailsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
