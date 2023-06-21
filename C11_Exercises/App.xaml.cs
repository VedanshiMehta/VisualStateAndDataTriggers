#if ANDROID
using Android.App;
using Android.Content;
using AndroidX.Core.App;
#endif
using C11_Exercises.View.Chapter12;
using C11_Exercises.View.Chapter14;
using C11_Exercises.View.Chapter15;
using C11_Exercises.View.Chapter16;
using C11_Exercises.View.Chapter17;
using C11_Exercises.View.Chapter18;
using C11_Exercises.View.Chapter19;
using C11_Exercises.View.Exercise1;
using C11_Exercises.View.Exercise2;
using Plugin.FirebasePushNotification;
using Plugin.LocalNotification;
using System.Collections.Immutable;
using Application = Microsoft.Maui.Controls.Application;
using Platform = Microsoft.Maui.ApplicationModel.Platform;

namespace C11_Exercises;

public partial class App : Application
{
    private string _title;
    private string _body;
    public App()
	{
       
		InitializeComponent();
		//RegisterForNotification();
		

		MainPage = new NavigationPage(new FluentValidationDemo())
		{
			BarBackgroundColor = Colors.CadetBlue,
			BarTextColor = Colors.White,
			
		};
	}

    [Obsolete]
    private void RegisterForNotification()
    {
      
        var token = CrossFirebasePushNotification.Current.Token;
        CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
        {
            Console.WriteLine($"TOKEN : {p.Token}");
        };
        CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
        {
#if ANDROID
            var a = p.Data.Values.ToList();
            _title = a[1].ToString();
            _body = a[0].ToString();

            var activity = Platform.WaitForActivityAsync().Result;
            var notificationManager = NotificationManager.FromContext(activity);
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel("channel", "Maui", NotificationImportance.High);

                notificationManager.CreateNotificationChannel(notificationChannel);
            }
            var intent = new Intent(activity, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.AddFlags(ActivityFlags.SingleTop);
            var pendingIntent = PendingIntent.GetActivity(activity, 101, intent, PendingIntentFlags.OneShot | PendingIntentFlags.Immutable);
            var notificationBuilder = new NotificationCompat.Builder(activity, "channel")
                                        .SetContentTitle(_title)
                                        .SetContentText(_body)
                                        .SetColorized(true)
                                        .SetAutoCancel(true)
                                        .SetColor(Resource.Color.colorAccent)
                                        .SetSmallIcon(Resource.Drawable.cricket)
                                        .SetPriority((int)Android.App.NotificationPriority.High)
                                        .SetContentIntent(pendingIntent);
            notificationManager.Notify(101, notificationBuilder.Build());
#else
#endif
        };
        MessagingCenter.Subscribe<MainActivity>(this, "NotificationTapped",
        (sender =>
        {
            MainPage.Navigation.PushAsync(new NotificationPage());
        }));
        //Push message received event 
        CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
        {
            var isProfileExist = p.Data.ToList().Exists(x => x.Key == "profile");
            if (!isProfileExist)
            {
                MainPage.Navigation.PushAsync(new NotificationPage());
            }
        };
    }

}


