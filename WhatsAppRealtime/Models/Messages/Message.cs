using WhatsAppRealtime.Models.Static;

namespace WhatsAppRealtime.Models.Messages;

public class Message(string emailSender, string emailReciver, string mensage)
{
    
    #region PropiedadesMensaje
    
    public string Id { set; get;} // id del key message
    
    public string IdChat { get; set; } = string.Empty; // id del chat
    
    public string EmailSender { get;} = emailSender;
    
    public string EmailReceiver { get;} = emailReciver;
    
    public string MensageStr { get;} = mensage;
    
    public bool? IsMe { get; set; } = null; // si empre null, y depende de usuario logueado cambia
    
    public DateTime HoraEnvio { get;} = DateTime.Now; // tiempo
    
    #endregion

    #region MetodosPrivados

    private static string GetMessageId(string us1, string us2)
    {
        var id = string.Empty;
        try
        {
            id = Utiles.OrdenarConcatenar(Utiles.SeparaUser(us1), Utiles.SeparaUser(us2));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error MessageModel, GetMessageId: "+e.Message);
        }
        return id;
    }

    #endregion
    
    #region Metodos Publicos

    public void ChangeIsMe(string emailUserLogeado)
    {
        if (emailUserLogeado.Equals(this.EmailSender))
        {
            this.IsMe = true;
        }
    }
    
    #endregion
    
}