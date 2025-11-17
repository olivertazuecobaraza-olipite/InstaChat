using WhatsAppRealtime.Models.Messages;
using WhatsAppRealtime.Models.Static;

namespace WhatsAppRealtime.Models.Chats;

public class Chat(string user1, string user2)
{
    
    #region Propiedades Chat

    public string Id { get; set; } // key
    
    public readonly string User1 = user1; // oliver.tazueco.baraza@...
    
    public readonly string User2 = user2; //usuaro2

    public string[] Title { get; set; } = [Utiles.SeparaUser(user1), Utiles.SeparaUser(user2)]; // array de nombre de chat para que cambie de nombre dependiendo de que usuario lo muestre

    //public List<Message> ListMensajes { get; set; } = new(); // lista de mensajes del chat
    
    #endregion
    
    
}