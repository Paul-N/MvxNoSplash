using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using MvxNoSplash.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxNoSplash.Android.Activities
{
    [Register("org.nosplash.activities.MainActivity")]
    [Activity(Label = "View for HomeViewModel", Theme = "@style/AppTheme.Launcher", MainLauncher = true)]
    public class MainActivity : MvxActivity
    {
        public MainActivity()
        {
        }

        public MainActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
    //    : SingleHostActivity<Setup, App>
    //{
    //    protected override int ResourceId => Resource.Layout.activity_main;

    //    protected override int ThemeId => Resource.Style.AppTheme;
    //}
}
