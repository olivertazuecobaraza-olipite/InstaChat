using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppRealtime.ViewModel.PostLogin.Main.Menu;

namespace WhatsAppRealtime.Pages.PostLogin.Main.Menu;

public partial class MenuPage : ContentPage
{
    public MenuPage(MenuPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}