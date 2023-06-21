using Android.App;
using Android.OS;
using Android.Runtime;
using Firebase;
using Plugin.FirebasePushNotification;

namespace C11_Exercises;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    public override void OnCreate()
    {
        base.OnCreate();
        //Set the default notification channel for your app when running Android Oreo
        if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
        {
            //Change for your default notification channel id here
            FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";
            //Change for your default notification channel name here
            FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
        }
        FirebaseApp.InitializeApp(this);
        FirebasePushNotificationManager.Initialize(this, false);
    }

}
