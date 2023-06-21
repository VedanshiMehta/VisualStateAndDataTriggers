namespace C11_Exercises.View.Exercise1;

public partial class Exercise1 : ContentPage
{
	public Exercise1()
	{
		InitializeComponent();
        GoToState(false);
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		bool valid = !string.IsNullOrWhiteSpace(entryEmail.Text) && !string.IsNullOrWhiteSpace(entryPassword.Text);
        GoToState(valid);
    }

    private void GoToState(bool valid)
    {
        string visualstate = valid ? "Valid" : "InValid";
        VisualStateManager.GoToState(buttonLogin, visualstate);
    }
}