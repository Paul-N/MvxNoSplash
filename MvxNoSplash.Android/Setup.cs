using Android.Content;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using MvxNoSplash.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace MvxNoSplash.Android
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override ILoggerFactory CreateLogFactory()
        {
            // serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override IMvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
        {
            return new ViewsContainer(applicationContext);
        }

        class ViewsContainer : MvxAndroidViewsContainer
        {
            public ViewsContainer(Context applicationContext) : base(applicationContext) { }

            public new Type GetViewType(Type? viewModelType)
            {
                return base.GetViewType(viewModelType);
            }
        }

        //        protected override IMvxAndroidViewPresenter CreateViewPresenter() => new TabViewPresenter(AndroidViewAssemblies);

        //#if NET6_0_OR_GREATER
        //        public new void PlatformInitialize(Activity activity)
        //        {
        //            base.PlatformInitialize(activity);
        //        }

        //        public new void PlatformInitialize(global::Android.App.Application application)
        //        {
        //            PlatformInitialize(application);
        //        }
        //#endif
        //#if OLD_XAMARIN
        //        public new void PlatformInitialize(Context applicationContext)
        //        {
        //            base.PlatformInitialize(applicationContext);
        //        }
        //#endif

        //        protected override IMvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
        //        {
        //            return base.CreateViewsContainer(applicationContext);
        //        }
    }
}
