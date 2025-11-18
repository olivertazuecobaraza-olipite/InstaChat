using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppRealtime.ViewModel.PostLogin.Main.Menu;

namespace WhatsAppRealtime.Pages.PostLogin.Main.Menu;

public partial class AddChatPage : ContentPage
{
    public AddChatPage(AddChatPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}