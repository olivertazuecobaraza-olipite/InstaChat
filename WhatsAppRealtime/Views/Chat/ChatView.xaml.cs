namespace WhatsAppRealtime.Views.Chat;

public partial class ChatView : ContentView
{
    public ChatView()
    {
        InitializeComponent();
    }
    // nombre de chat
    public static readonly BindableProperty NombreChatProperty = BindableProperty.Create(nameof(NombreChat), typeof(string), typeof(ChatView), string.Empty);
    public string NombreChat
    {
        get => (string)GetValue(ChatView.NombreChatProperty);
        set => SetValue(ChatView.NombreChatProperty, value);
    }
    
    // ultimo mensaje
    public static readonly BindableProperty LastMesageProperty = BindableProperty.Create(nameof(LastMesage), typeof(string), typeof(ChatView), string.Empty);

    public string LastMesage
    {
        get => (string)GetValue(ChatView.LastMesageProperty);
        set => SetValue(ChatView.LastMesageProperty, value); 
    }
    
    // fecha ultimo mensage
    public static readonly BindableProperty DateLastMessageProperty = BindableProperty.Create(nameof(DateLastMessage), typeof(DateTime), typeof(ChatView), null);

    public DateTime DateLastMessage
    {
        get => (DateTime)GetValue(ChatView.DateLastMessageProperty);
        set => SetValue(ChatView.DateLastMessageProperty, value);
    }
}