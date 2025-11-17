using WhatsAppRealtime.Models.Static;

namespace WhatsAppRealtime.Models.Messages;

public class Message(string emailSender, string emailReciver, string mensage)
{
    
    #region PropiedadesMensaje
    
    public string Id { set; get;} // id del key message
    
    public string IdChat { get; set; } = string.Empty; // id del chat
    
    public string EmailSender { get; set; } = emailSender;
    
    public string EmailReceiver { get; set; } = emailReciver;
    
    public string MensageStr { get; set; } = mensage;
    
    public bool? IsMe { get; set; } = null; // si empre null, y depende de usuario logueado cambia
    
    public DateTime HoraEnvio { get; set; } = DateTime.Now; // tiempo
    
    #endregion
    
}