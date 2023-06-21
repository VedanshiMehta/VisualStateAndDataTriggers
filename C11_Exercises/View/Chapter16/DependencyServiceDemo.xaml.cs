namespace C11_Exercises.View.Chapter16;

public partial class DependencyServiceDemo : ContentPage
{
	public DependencyServiceDemo()
	{
		InitializeComponent();
        var service = DependencyService.Get<IDeviceOrientationService>();
        labelPlatform.Text = service.Platform;
        labelOrientation.Text = "Orientation: " + service.GetOrientation();
    }
}