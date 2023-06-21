﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Plugin.FirebasePushNotification;

namespace C11_Exercises;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        FirebasePushNotificationManager.ProcessIntent(this, Intent);
    }


    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        MessagingCenter.Send<MainActivity>(this, "NotificationTapped");
    }
}

