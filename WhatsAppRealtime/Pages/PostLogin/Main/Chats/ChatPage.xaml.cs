using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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