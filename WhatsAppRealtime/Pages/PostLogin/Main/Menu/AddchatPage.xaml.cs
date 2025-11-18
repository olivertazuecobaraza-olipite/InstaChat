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