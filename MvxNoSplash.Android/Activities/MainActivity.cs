using Android.Runtime;

namespace MvxNoSplash.Android.Activities
{
    [Register("org.nosplash.activities.MainActivity")]
    [Activity(Label = "MainActivity", Theme = "@style/AppTheme.Launcher"
        , MainLauncher = true
        )]
    public class MainActivity : SingleHostActivity
    {
        protected override int ResourceId => Resource.Layout.activity_main;

        protected override int ThemeId => Resource.Style.AppTheme_NoActionBar;
    }
}
