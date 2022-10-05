using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using MvvmCross;
using MvvmCross.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;

namespace MvxNoSplash.Android.Activities
{
    [Register("evilgenius.tabbednavigation.SingleHostActivity2")]
    public abstract class SingleHostActivity2 : AppCompatActivity, IMvxSetupMonitor
    {
        protected const int NoContent = 0;

        protected abstract int ResourceId { get; }

        protected abstract int ThemeId { get; }

        private Bundle _bundle;

        protected SingleHostActivity2() { }

        protected SingleHostActivity2(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        protected override void OnCreate(Bundle bundle)
        {
            SetTheme(ThemeId);

            _bundle = bundle;

            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
            setup.InitializeAndMonitor(this);

            base.OnCreate(bundle);

            if (ResourceId != NoContent)
            {
                // Set our view from the "splash" layout resource
                // Be careful to use non-binding inflation
                var content = LayoutInflater.Inflate(ResourceId, null);
                SetContentView(content);
            }
        }

        private bool _isResumed;

        protected override void OnResume()
        {
            base.OnResume();
            _isResumed = true;
            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
            setup.InitializeAndMonitor(this);
        }

        protected override void OnPause()
        {
            _isResumed = false;
            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
            setup.CancelMonitor(this);
            base.OnPause();
        }

        public virtual async Task InitializationComplete()
        {
            if (!_isResumed)
                return;

            await RunAppStartAsync(_bundle);
        }

        protected virtual async Task RunAppStartAsync(Bundle bundle)
        {
            if (Mvx.IoCProvider.TryResolve(out IMvxAppStart startup))
            {
                if (!startup.IsStarted)
                    await startup.StartAsync(GetAppStartHint(bundle));
            }
        }

        protected virtual object GetAppStartHint(object hint = null) => hint;
    }
}
