using Android.Content;
using Android.Runtime;
using Android.Views;
using MvvmCross;
using MvvmCross.Core;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;

namespace MvxNoSplash.Android.Activities
{
    [Register("evilgenius.tabbednavigation.SingleHostActivity")]
    public abstract class SingleHostActivity : MvxActivity, IMvxSetupMonitor
    {
        protected const int NoContent = 0;

        protected abstract int ResourceId { get; }

        protected abstract int ThemeId { get; }

        private Bundle _bundle;

        public new MvxNullViewModel ViewModel
        {
            get => base.ViewModel as MvxNullViewModel;
            set => base.ViewModel = value;
        }

        protected SingleHostActivity() { }

        protected SingleHostActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        protected override void OnCreate(Bundle bundle)
        {
            SetTheme(ThemeId);



            _bundle = bundle;

            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
            setup.InitializeAndMonitor(this);

            base.OnCreate(bundle);


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

            if (ResourceId != NoContent)
            {
                // Set our view from the "splash" layout resource
                // Be careful to use non-binding inflation
                //var content = LayoutInflater.Inflate(ResourceId, null);
                //SetContentView(content);
                //SetContentView(ResourceId);

                //_view = this.BindingInflate(ResourceId, null);
                //SetContentView(_view);

                //var ctx = BaseContextToAttach(this) is _MvxContextWrapper;
                //if (ctx)
                //{
                //    var ioc = Mvx.IoCProvider;
                    //_view = this.BindingInflate(ResourceId, null);
                    SetContentView2(ResourceId);
                //}
            }
            await RunAppStartAsync(_bundle);
        }

        public void SetContentView2(int layoutResID)
        {
            if (BaseContextToAttach2(this) is _MvxContextWrapper)
            {
                _view = this.BindingInflate(layoutResID, null);
                SetContentView(_view);
                return;
            }
        }

        protected Context BaseContextToAttach2(Context @base) => _MvxContextWrapper.Wrap(@base, this);

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
