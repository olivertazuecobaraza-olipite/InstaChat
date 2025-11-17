using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Pages.PreLogin.Register;
using WhatsAppRealtime.Services.Firebase;
using WhatsAppRealtime.ViewModel.PreLogin.Register;

namespace WhatsAppRealtime.ViewModel.PreLogin.Login;

public partial class LoginPageViewModel(FireBaseAuth fba) : ObservableObject
{
    #region Properties

    private readonly FireBaseAuth _fba = fba;

    #endregion
    
    #region Observable Properties

    [ObservableProperty] private string _email = "oliver.tazueco.baraza@iestubalcain.net";
    [ObservableProperty] private string _password = "damdam";
    [ObservableProperty] private string _confirmPassword = "damdam";

    #endregion

    #region Commands

    [RelayCommand]
    private void GoToRegisterPage()
    {
        var registerPage = Application.Current?.Windows[0].Page?.Handler?.MauiContext?.Services.GetService<RegisterPage>();
        //Application.Current.Windows[0].Page = new RegisterPage(new RegisterPageViewModel(new FireBaseAuth()));
        Application.Current?.Windows[0].Page?.Navigation.PushAsync(registerPage);
    }
 
    [RelayCommand]
    private async Task IniciarSesion()
    {
        if (Utiles.TestPassword(Email, Password, ConfirmPassword) && await _fba.IniciarSesion(Email, Password))
        {
            GoToShell();
        }
        else
        {
            await Utiles.AlertasMalas("Error al iniciar sesion");
        }
    }

    #endregion
    
    #region Metodos privados
    private static void GoToShell()
    {
        Application.Current!.Windows[0].Page = new AppShell();
    }
    
    #endregion
}