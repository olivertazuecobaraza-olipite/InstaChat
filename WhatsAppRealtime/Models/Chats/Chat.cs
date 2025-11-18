using WhatsAppRealtime.Models.Messages;
using WhatsAppRealtime.Models.Static;

namespace WhatsAppRealtime.Models.Chats;

public class Chat(string user1, string user2)
{

    #region Propiedades Chat

    public string Id { get; set; } = string.Empty; // key
    
    public readonly string User1 = user1; // oliver.tazueco.baraza@...
    
    public readonly string User2 = user2; //usuaro2

    public string[] Title { get; set; } = [Utiles.SeparaUser(user1), Utiles.SeparaUser(user2)];

    public string UsuarioLogueado { get; set; } = string.Empty;

    public string NombreVisible
    {
        get
        {
            if (Title == null || Title.Length < 2)
                return "";

            return Utiles.SeparaUser(UsuarioLogueado) == Title[0] ? Title[1] : Title[0];
        }
    }

    public string LastMessage { get; set; } = string.Empty;

    public DateTime HoraEnvio { get; set; }
    #endregion

}