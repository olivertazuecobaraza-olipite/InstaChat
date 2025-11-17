using CommunityToolkit.Maui;
using MauiIcons.Material;
using Microsoft.Extensions.Logging;

using WhatsAppRealtime.Pages.PostLogin.Main.Chats;
using WhatsAppRealtime.Pages.PostLogin.Main.Menu;
using WhatsAppRealtime.Pages.PostLogin.Profile;
using WhatsAppRealtime.Pages.PreLogin.Login;
using WhatsAppRealtime.Pages.PreLogin.Register;
using WhatsAppRealtime.Services.Firebase;
using WhatsAppRealtime.ViewModel.PostLogin.Main.Chats;
using WhatsAppRealtime.ViewModel.PostLogin.Main.Menu;
using WhatsAppRealtime.ViewModel.PostLogin.Profile;
using WhatsAppRealtime.ViewModel.PreLogin.Login;
using WhatsAppRealtime.ViewModel.PreLogin.Register;

namespace WhatsAppRealtime;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMaterialMauiIcons()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("RobotoMono-VariableFont_wght.ttf", "RobotoMonoVariableFont");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
    
        builder.Services.StartServices(); // servicios
        builder.Services.StartPageViewModel(); // Pages y vm
        
        return builder.Build();
    }

    #region Metodos Servicios

    // Pages
    private static void StartPageViewModel(this IServiceCollection service)
    {
        // pre Login
        service.AddTransient<RegisterPageViewModel>();
        service.AddTransient<RegisterPage>();
        
        service.AddTransient<LoginPageViewModel>();
        service.AddTransient<LoginPage>();
        
        // post login
        service.AddTransient<ChatPageViewModel>();
        service.AddTransient<ChatPage>();
        
        service.AddTransient<MenuPageViewModel>();
        service.AddTransient<MenuPage>();

        service.AddTransient<ProfilePageViewModel>();
        service.AddTransient<ProfilePage>();
    }
    
    // Services
    private static void StartServices(this IServiceCollection service)
    {
        // Firebase
        service.AddScoped<FireBaseAuth>();
        service.AddScoped<FireBaseRealTime>();
    }

    #endregion
    
}