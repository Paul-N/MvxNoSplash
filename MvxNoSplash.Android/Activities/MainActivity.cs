using Android.Runtime;
using MvxNoSplash.Core;

namespace MvxNoSplash.Android.Activities
{
    [Register("org.nosplash.activities.MainActivity")]
    [Activity(Label = "View for HomeViewModel", Theme = "@style/AppTheme.Launcher"
        //, MainLauncher = true
        )]
    public class MainActivity : SingleHostActivity2
    {
        protected override int ResourceId => Resource.Layout.activity_main;

        protected override int ThemeId => Resource.Style.AppTheme;
    }
}
