using WhatsAppRealtime.Pages.PostLogin.Main.Chats;

namespace WhatsAppRealtime;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("ChatPage", typeof(ChatPage));
    }
}