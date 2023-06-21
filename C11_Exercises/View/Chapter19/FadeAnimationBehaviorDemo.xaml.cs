using CommunityToolkit.Maui.Views;

namespace C11_Exercises.View.Chapter19;

public partial class FadeAnimationBehaviorDemo : ContentPage
{
	public FadeAnimationBehaviorDemo()
	{
		InitializeComponent();
	}
    private async void DisplayPopupClicked(object sender, EventArgs e)
    {
        var popup = new CustomPopUp();
        var result = await this.ShowPopupAsync(popup);
        if (result is bool boolResult)
        {
            if (boolResult)
            {
                await Console.Out.WriteLineAsync("Yes");
                // Yes was tapped
            }
            else
            {
                await Console.Out.WriteLineAsync("No");
                // No was tapped
            }
        }
    }
}