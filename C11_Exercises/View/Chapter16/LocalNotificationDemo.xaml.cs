using Plugin.LocalNotification;

namespace C11_Exercises.View.Chapter16;

public partial class LocalNotificationDemo : ContentPage
{
	public LocalNotificationDemo()
	{
		InitializeComponent();
    }
    private void ShowNotificationButtonClicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest
        {
            NotificationId = 1000,
            Title = "Watch the TATA IPL",
            Subtitle = "For you",
            Description = "Streaming Free from 31st March, Enjoy",
            //Schedule = new NotificationRequestSchedule
            //{
            //    NotifyTime = DateTime.Now.AddSeconds(5),
            //},
            ReturningData = "Tapped on notification",
            Android =
            {
                IconSmallName =
                {
                    ResourceName="cricket"
                },
                Color =
                {
                    ResourceName="colorPrimary"
                }
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }

}