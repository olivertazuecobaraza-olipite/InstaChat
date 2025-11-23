using System.Collections.ObjectModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database.Query;
using WhatsAppRealtime.Models.Chats;
using WhatsAppRealtime.Services.Firebase;

using Firebase.Database.Streaming;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Pages.PostLogin.Main.Chats;
using WhatsAppRealtime.Pages.PostLogin.Main.Menu;
using WhatsAppRealtime.Models.Messages;

namespace WhatsAppRealtime.ViewModel.PostLogin.Main.Menu;

public partial class MenuPageViewModel : ObservableObject
{
    #region Servicios

    private readonly FireBaseRealTime _fbr;
    private readonly FireBaseAuth _fba;
    
    #endregion
    
    #region Obserevables

    [ObservableProperty] private ObservableCollection<Chat> _chats = new();

    #endregion

    #region Constructor

    public MenuPageViewModel(FireBaseAuth fba, FireBaseRealTime fbr)
    {
        _fbr = fbr;
        _fba = fba;
        StartListenChats();
        
    }
    
    #endregion
    
    #region Commands

    [RelayCommand]
    private async Task AddChat()
    {

        var createChat = Shell.Current.Handler?.MauiContext?.Services.GetService<AddChatPage>();
        await Shell.Current.Navigation.PushAsync(createChat);

    }
    
    [RelayCommand]
    private async Task DeleteChat(Chat chat)
    {
        
        var respuesta = await Utiles.AlertaPreguntaShell("Estas seguro que quieres eliminar el chat?");
        if (respuesta)
        {
            if (await _fbr.DeleteChat(chat))
            {
                Utiles.CrearToast("Chat eliminado");
            }
            else
            {
                await Utiles.AlertasMalasShell("No se ha eliminado");
            }
        }
    }
    
    // ir al chat
    [RelayCommand]
    private async Task IrChat(Chat chat)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Chat", chat }
        };
        await Shell.Current.GoToAsync(nameof(ChatPage), navigationParameter);
    }
    #endregion
    
    #region RealTime
    
    // start Chats
    private void StartListenChats()
    {
        _fbr.Instance.Child("chat").AsObservable<Chat>().Subscribe((chat) =>
        {
            if (chat.Object == null) return;
            chat.Object.Id = chat.Key;

            if (!chat.Object.User1.Equals(_fba.ObtenerEmail().ToLower()) && !chat.Object.User2.Equals(_fba.ObtenerEmail().ToLower()))
            {
                return;
            }
            
            chat.Object.UsuarioLogueado = _fba.ObtenerEmail();
            var existeChat = Chats.FirstOrDefault(c => c.Id == chat.Key);
            
            if (chat.EventType == FirebaseEventType.InsertOrUpdate)
            {
                if (existeChat == null) // insertar
                {
                    Chats.Add(chat.Object);
                }
                else
                {
                    int index = Chats.IndexOf(existeChat);
                    if (index != -1)
                    {
                        Chats[index] = chat.Object;
                    }
                }
            }
            else if (chat.EventType == FirebaseEventType.Delete)
            {
                if (existeChat != null)
                {
                    Chats.Remove(chat.Object);
                }
            }
        });
    }

    #endregion
}
