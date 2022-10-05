using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;
using MvxNoSplash.Core;

namespace MvxNoSplash.Android.Activities
{
    [Activity(Label = "Old splash", 
        MainLauncher = true, 
        NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/AppTheme.Launcher")]
    public class SplashActivity : MvxSplashScreenActivity//<Setup, App>
    {
        public SplashActivity() : base(Resource.Layout.activity_splash) { }
    }
}
