using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxNoSplash.Core.ViewModels;

namespace MvxNoSplash.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<HomeViewModel>();
        }
    }
}