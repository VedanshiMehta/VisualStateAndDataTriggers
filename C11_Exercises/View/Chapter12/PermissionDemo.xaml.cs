using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace C11_Exercises.View.Chapter12;

public partial class PermissionDemo : ContentPage
{
    private PermissionStatus _permissionStatus;
	public PermissionDemo()
	{
		InitializeComponent();
	}

    private async void ButtonAccessPermission_Clicked(object sender, EventArgs e)
    {
		PermissionStatus permissionStatus = await CheckPermissionStatus();
		if(permissionStatus == PermissionStatus.Granted) 
        { 
            await Toast.Make("Permission granted",ToastDuration.Short).Show();
        }
    }

    private async Task<PermissionStatus> CheckPermissionStatus()
    {
        try
        {
            _permissionStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (_permissionStatus != PermissionStatus.Granted)
            {
                bool shouldShowRationale = Permissions.ShouldShowRationale<Permissions.Camera>();
                if (shouldShowRationale)
                {
                    await ShowRationaleSialoge();
                }
                _permissionStatus = await Permissions.RequestAsync<Permissions.Camera>();
                if (_permissionStatus != PermissionStatus.Granted)
                {
                    shouldShowRationale = Permissions.ShouldShowRationale<Permissions.Camera>();
                    if (!shouldShowRationale)
                    {
                        await NavigateToAppSettings();
                    }
                    return _permissionStatus;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return _permissionStatus;
       
    }

    private async Task NavigateToAppSettings()
    {
        bool openSettings = await DisplayAlert("Enable Permission","Please enable camera permission", "Ok","Cancel");
        if (openSettings)
        {
            AppInfo.ShowSettingsUI();
        }

    }

    private async Task ShowRationaleSialoge()
    {
        await DisplayAlert("Camera Permission Required","This permission is needed to capture photos","Ok");
    }
}