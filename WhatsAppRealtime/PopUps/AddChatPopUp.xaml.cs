using CommunityToolkit.Maui.Views;

namespace WhatsAppRealtime.PopUps;

public partial class AddChatPopUp : Popup
{
    public AddChatPopUp()
    {
        InitializeComponent();
    }
    private async Task OnSaveClicked(object sender, EventArgs e)
    {
        await CloseAsync(InputEntry.Text);
    }
}