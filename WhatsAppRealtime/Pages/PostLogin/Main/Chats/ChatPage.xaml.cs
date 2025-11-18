using WhatsAppRealtime.ViewModel.PostLogin.Main.Chats;

namespace WhatsAppRealtime.Pages.PostLogin.Main.Chats;

public partial class ChatPage : ContentPage
{
    public ChatPage(ChatPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}