using WhatsAppRealtime.Pages.PreLogin.Login;
using WhatsAppRealtime.Services.Firebase;
using WhatsAppRealtime.ViewModel.PreLogin.Login;

namespace WhatsAppRealtime;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }
 
    protected override Window CreateWindow(IActivationState? activationState)
    {
        var loginPage = new LoginPage(new LoginPageViewModel(new FireBaseAuth()));
        //NavigationPage.SetHasNavigationBar(loginPage, false);
        var nav = new NavigationPage(loginPage);
        return new Window(nav);
    }
    
}