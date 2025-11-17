using WhatsAppRealtime.ViewModel.PostLogin.Profile;

namespace WhatsAppRealtime.Pages.PostLogin.Profile;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfilePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}