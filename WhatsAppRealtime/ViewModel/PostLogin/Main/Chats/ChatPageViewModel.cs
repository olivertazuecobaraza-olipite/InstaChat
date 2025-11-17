using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using WhatsAppRealtime.Models.Chats;
using WhatsAppRealtime.Models.Messages;
using WhatsAppRealtime.Models.Static;
using WhatsAppRealtime.Services.Firebase;

namespace WhatsAppRealtime.ViewModel.PostLogin.Main.Chats;


public partial class ChatPageViewModel(FireBaseRealTime fbr) : ObservableObject, IQueryAttributable
{
    
    #region Observables

    [ObservableProperty] private Chat? _chatActual;
    [ObservableProperty] private ObservableCollection<Message> _mensajes = new();
    [ObservableProperty] private string _textoMensaje = string.Empty;

    #endregion
    
    #region Commands
    // enviar
    [RelayCommand]
    private async Task Enviar()
    {
        var nuvoMensaje = new Message("emailSender", "emailReciver", TextoMensaje);
        nuvoMensaje.IdChat = ChatActual.Id;
        
        //_fbr.Instance.Child("message").PostAsync(nuvoMensaje);  
        if (TextoMensaje.Equals(string.Empty))
        {   
            await Utiles.AlertasMalasShell("No hay texto");
            TextoMensaje = string.Empty;
        }
        else
        {
            if (await fbr.AddMessage(nuvoMensaje))
            {
                Utiles.CrearToast("Enviado");
                TextoMensaje = string.Empty;
            }
            else
            {
                await Utiles.AlertasMalasShell("Algo ha salido Mal");
            }
        }
    }
    #endregion
    
    #region Metodos
    // metodos
    #endregion
    
    #region parametro
    // parametro
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ChatActual = query["Chat"] as Chat;

        if (ChatActual != null)
        {
            ListenMessage();
        }
    }
    #endregion
    
    #region RelaTime
    
    // start Chats
    private void ListenMessage()
    {
        fbr.Instance.Child("message")
            .AsObservable<Message>()
            .Subscribe((message) =>
        {
            if (message.Object == null) return;
            
            message.Object.Id = message.Key;

            if (message.Object.IdChat != ChatActual.Id) return;
            
            var existeMessage = Mensajes.FirstOrDefault(c => c.Id == message.Key);
            
            if (message.EventType == FirebaseEventType.InsertOrUpdate)
            {
                if (existeMessage == null) // insertar
                {
                    Mensajes.Add(message.Object);
                }
                else
                {
                    // Update chat hacer
                }
            }
            
        });
    }
    
    #endregion
    
}