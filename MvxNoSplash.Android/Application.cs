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
        }

        public Application(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
