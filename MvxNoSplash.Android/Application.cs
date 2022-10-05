using System;

using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using MvxNoSplash.Core;

namespace MvxNoSplash.Android
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
        public class Application : MvxAndroidApplication<Setup, App>
    {
        public Application() : base()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }
        
        public Application(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        private void TaskSchedulerOnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            global::Android.Util.Log.Wtf("!!!!!!", "TaskSchedulerOnUnobservedTaskException");
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            global::Android.Util.Log.Wtf("!!!!!!", "CurrentDomainOnUnhandledException");
        }
    }
}
