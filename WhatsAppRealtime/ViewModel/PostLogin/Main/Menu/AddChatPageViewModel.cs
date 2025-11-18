using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhatsAppRealtime.Models.Chats;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Services.Firebase;

namespace WhatsAppRealtime.ViewModel.PostLogin.Main.Menu;

public partial class AddChatPageViewModel(FireBaseRealTime fbr, FireBaseAuth fba) : ObservableObject
{
    #region Observables

    [ObservableProperty] private string _email = string.Empty;

    #endregion
    
    #region Servicios

    private readonly FireBaseRealTime _fbr = fbr;
    private readonly FireBaseAuth _fba = fba;

    #endregion

    #region Commands

    [RelayCommand]
    private async Task AddChat()
    {
        if (Email.Equals(string.Empty))
        {
            await Utiles.AlertasMalasShell("Campo vacio");
            return;
        }
        
        var chatNuevo = new Chat(_fba.ObtenerEmail(), Email);
        if (await _fbr.CrearChat(chatNuevo))
        {
            Email = string.Empty;
            Utiles.CrearToast("Chat Creado");
            await Shell.Current.Navigation.PopAsync();
        }
        else
        {
            await Utiles.AlertasMalasShell("Error al crear el chat");
            Email = string.Empty;
        }
    }
    
    #endregion

}