using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Services.Firebase;

namespace WhatsAppRealtime.ViewModel.PreLogin.Register;

public partial class RegisterPageViewModel(FireBaseAuth fba) : ObservableObject
{
    
    #region Properties

    private readonly FireBaseAuth _fba = fba;

    #endregion
    
    #region Observable Properties

    [ObservableProperty] private string _email = string.Empty;
    [ObservableProperty] private string _password = string.Empty;
    [ObservableProperty] private string _confirmPassword = string.Empty;

    #endregion
    
    #region Commands

    [RelayCommand]
    private async Task Registrarse()
    {
        if (_fba.RegistrarUsuario(Email, Password) && Utiles.TestPassword(Email, Password, ConfirmPassword))
        {
            await Application.Current.Windows[0].Page.Navigation.PopAsync();
        }
        else
        {
            ResetProperties();
            await Utiles.AlertasMalas("Error al crear el usuario");
        }
    }
    
    #endregion
    
    #region Metodos

    private void ResetProperties()
    {
        Email = string.Empty;
        Password = string.Empty;
        ConfirmPassword = string.Empty;
    }
    
    #endregion
}