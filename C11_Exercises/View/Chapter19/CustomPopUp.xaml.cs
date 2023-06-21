using CommunityToolkit.Maui.Views;

namespace C11_Exercises.View.Chapter19;

public partial class CustomPopUp : Popup
{
	public CustomPopUp()
	{
		InitializeComponent();
	}
    private void YesButtonClicked(object sender, EventArgs e)
    {
        Close(true);
    }
    private void NoButtonClicked(object sender, EventArgs e)
    {
        Close(false);
    }
}