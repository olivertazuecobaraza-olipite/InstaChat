using Firebase.Database;
using Firebase.Database.Query;
using WhatsAppRealtime.Models.Chats;
using WhatsAppRealtime.Models.Messages;

namespace WhatsAppRealtime.Services.Firebase;

public class FireBaseRealTime()
{
    #region Instancia

    public readonly FirebaseClient Instance = new("");

    #endregion
    
    #region metodos

     #region Chats

    // Crear un Chat
    public async Task<bool> CrearChat(Chat chat)
    {
        var r = false;
        try
        {
            var k = await Instance.Child("chat").PostAsync(chat);
            chat.Id = k.Key;
            await Instance.Child("chat").Child(k.Key).PutAsync(chat);
            r = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error-FireRealTime, CrearChat Error: " + e.Message);
        }
        return r;
    }
    
    
    // delete chat
    public async Task<bool> DeleteChat(Chat chat)
    {
        var r = false;
        try
        {
            
            await Instance.Child("chat").Child(chat.Id).DeleteAsync();
            r = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error-FireBaseRealtime, DeleteChat Error: " + e.Message);
        }
        return r;
    }
    
    //Update chat
    public async Task<bool> UpdateChatAsync(Chat chatAActualizar)
    {
        var r = false;
        try
        {
            await Instance
                .Child("chat")
                .Child(chatAActualizar.Id) 
                .PutAsync(chatAActualizar);
            r = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error-FireBaseRealtime, UpdateChat Error: {ex.Message}");
        }
        return r;
    }

    #endregion

    #region Messages

    public async Task<bool> AddMessage(Message message)
    {
        var r = false;
        try
        {
            var k = await Instance.Child("message").PostAsync(message);
            message.Id = k.Key;
            await Instance.Child("message").Child(k.Key).PutAsync(message);
            r = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error-FireRealtime, CrearMessage Error: " + e.Message);
        }
        return r;
    }

    #endregion
    
    #endregion
}
