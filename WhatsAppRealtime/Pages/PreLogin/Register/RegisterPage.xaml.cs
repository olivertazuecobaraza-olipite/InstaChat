using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppRealtime.ViewModel.PreLogin.Register;

namespace WhatsAppRealtime.Pages.PreLogin.Register;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}