using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhatsAppRealtime.Models.Chats;
using WhatsAppRealtime.Services.Firebase;

using Firebase.Database.Streaming;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Pages.PostLogin.Main.Chats;

namespace WhatsAppRealtime.ViewModel.PostLogin.Main.Menu;

public partial class MenuPageViewModel : ObservableObject
{
    #region Servicios

    private readonly FireBaseRealTime _fbr;
    
    #endregion
    
    #region Obserevables

    [ObservableProperty] private ObservableCollection<Chat> _chats = new();
    [ObservableProperty] private string _email;

    #endregion
    
    #region Constructor
    
    public MenuPageViewModel(FireBaseRealTime fbr)
    {
        _fbr = fbr;
        Email = fbr.ObtenerEmail();
        StartListenChats();
    }
    
    #endregion
    
    #region Commands

    [RelayCommand]
    private async Task AddChat()
    {
        var chat = new Chat("oliver", "User");
        if (await _fbr.CrearChat(chat))
        {
            await Utiles.AlertasBuenaShell("Chat credo correctamente");
        }
        else
        {
            await Utiles.AlertasMalasShell("Error al crear el Chat");
        }
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

            var existeChat = Chats.FirstOrDefault(c => c.Id == chat.Key);
            
            if (chat.EventType == FirebaseEventType.InsertOrUpdate)
            {
                if (existeChat == null) // insertar
                {
                    //if (emailUserActual!= null &&chat.Object.Id.Contains(Utiles.SeparaUser(emailUserActual))){ Chats.Add(chat.Object); }
                    Chats.Add(chat.Object);
                }
            }
            else if (chat.EventType ==  FirebaseEventType.Delete)
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
