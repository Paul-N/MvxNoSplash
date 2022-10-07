using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
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
                .WriteTo.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override MvxBindingBuilder CreateBindingBuilder()
        {
            return base.CreateBindingBuilder();
        }

        protected override void InitializeLastChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeLastChance(iocProvider);
        }
    }
}
