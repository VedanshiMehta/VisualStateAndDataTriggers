using Android.Content;
using Android.Runtime;
using Android.Views;


namespace C11_Exercises
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
        public string Platform { get; set; }

        public DeviceOrientationService()
        {
            Platform = "Android";
        }

        public string GetOrientation()
        {


            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;
            return isLandscape ? "Landscape" : "Potrait";
        }

    }
}