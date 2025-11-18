using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using WhatsAppRealtime.Models.Chats;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Services.Firebase;

namespace WhatsAppRealtime.ViewModel.PostLogin.Main.Menu
{
    public partial class AddChatPageViewModel(FireBaseAuth fba, FireBaseRealTime fbr) : ObservableObject
    {

        #region Observables

        [ObservableProperty] private string _emailReciver = string.Empty;

        #endregion


        #region Commands

        [RelayCommand]
        private async Task AddChat()
        {
            var chatNuevo = new Chat(fba.ObtenerEmail(), EmailReciver);
            if (await fbr.CrearChat(chatNuevo))
            {
                Utiles.CrearToast("Chat Creado correctamente");
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Utiles.AlertasMalasShell("Error al crear el Chat");
                EmailReciver = string.Empty;
            }
        }

        #endregion  
    }
}
