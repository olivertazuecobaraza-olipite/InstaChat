using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Pages.PreLogin.Login;
using WhatsAppRealtime.Services.Firebase;
using WhatsAppRealtime.ViewModel.PreLogin.Login;

namespace WhatsAppRealtime.ViewModel.PostLogin.Profile;

public partial class ProfilePageViewModel : ObservableObject
{
    #region Services

    private readonly FireBaseAuth _fba;

    #endregion
    
    #region Observables

    [ObservableProperty] private string _sourceImage = "profile.png";
    [ObservableProperty] private string _email;
    #endregion

    #region Construcor

    public ProfilePageViewModel(FireBaseAuth fba)
    {
        _fba = fba;
        Email = _fba.ObtenerEmail();
    }

    #endregion
    
    
    #region Commands

    [RelayCommand]
    private async Task CerrarSesion()
    {
       
        if (_fba.CerrarSesion())
        {
            //await Utiles.AlertasMalasShell("No se ha podido cerrar sesion");

            
            var loginPage = new LoginPage(new LoginPageViewModel(new FireBaseAuth()));
            var nav = new NavigationPage(loginPage);
        
            Application.Current.Windows[0].Page = nav;
            
        }
        else
        {
            await Utiles.AlertasMalasShell("No se ha podido cerrar sesion");
        }
    }
    
    #endregion 
}