//using Android.Runtime;
//using Android.Views;
//using MvvmCross;
//using MvvmCross.Core;
//using MvvmCross.Platforms.Android.Core;
//using MvvmCross.Platforms.Android.Views;
//using MvvmCross.ViewModels;

//namespace MvxNoSplash.Android.Activities
//{
//    [Register("evilgenius.tabbednavigation.SingleHostActivity")]
//    public abstract class SingleHostActivity<TMvxAndroidSetup, TApplication> : MvxActivity, IMvxSetupMonitor
//        where TMvxAndroidSetup : MvxAndroidSetup<TApplication>, new()
//        where TApplication : class, IMvxApplication, new()
//    {
//        protected const int NoContent = 0;

//        protected abstract int ResourceId { get; }

//        protected abstract int ThemeId { get; }

//        private Bundle _bundle;

//        public new MvxNullViewModel ViewModel
//        {
//            get => base.ViewModel as MvxNullViewModel;
//            set => base.ViewModel = value;
//        }

//        protected SingleHostActivity() => RegisterSetup();

//        protected SingleHostActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

//        protected virtual void RequestWindowFeatures() 
//            => RequestWindowFeature(WindowFeatures.NoTitle);

//        protected override void OnCreate(Bundle bundle)
//        {
//            SetTheme(ThemeId);

//            RequestWindowFeatures();

//            _bundle = bundle;

//            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
//            setup.InitializeAndMonitor(this);

//            base.OnCreate(bundle);

//            if (ResourceId != NoContent)
//            {
//                // Set our view from the "splash" layout resource
//                // Be careful to use non-binding inflation
//                var content = LayoutInflater.Inflate(ResourceId, null);
//                SetContentView(content);
//            }
//        }

//        private bool _isResumed;

//        protected override void OnResume()
//        {
//            base.OnResume();
//            _isResumed = true;
//            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
//            setup.InitializeAndMonitor(this);
//        }

//        protected override void OnPause()
//        {
//            _isResumed = false;
//            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
//            setup.CancelMonitor(this);
//            base.OnPause();
//        }

//        public virtual async Task InitializationComplete()
//        {
//            if (!_isResumed)
//                return;

//            await RunAppStartAsync(_bundle);
//        }

//        protected virtual async Task RunAppStartAsync(Bundle bundle)
//        {
//            if (Mvx.IoCProvider.TryResolve(out IMvxAppStart startup))
//            {
//                if (!startup.IsStarted)
//                    await startup.StartAsync(GetAppStartHint(bundle));
//            }
//        }

//        protected virtual object GetAppStartHint(object hint = null) => hint;

//        protected virtual void RegisterSetup() 
//            => this.RegisterSetupType<TMvxAndroidSetup>();
//    }
//}
