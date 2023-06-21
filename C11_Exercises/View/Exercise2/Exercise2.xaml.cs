using System.Runtime.CompilerServices;

namespace C11_Exercises.View.Exercise2;

public partial class Exercise2 : ContentPage
{
    private Button current;
    private Button previous;
	public Exercise2()
	{
		InitializeComponent();
        GoToState(buttonXS);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var clickedButton = (Button)sender;
        GoToState(clickedButton);
    }

    private void GoToState(Button clickedButton)
    {
        VisualStateManager.GoToState(clickedButton, "SelectedColor");
        ResetUnSelectedButtons(clickedButton);
    }

    private void ResetUnSelectedButtons(Button clickedButton)
    {
        foreach (var button in horizontalLayout.Children.OfType<Button>().Where(b => b != clickedButton))
        {
            VisualStateManager.GoToState(button, "UnselectedColor");
        }
    }
}