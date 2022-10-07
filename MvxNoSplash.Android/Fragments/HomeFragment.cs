using Android.Runtime;
using Android.Views;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvxNoSplash.Core.ViewModels;

namespace MvxNoSplash.Android.Fragments
{
    [MvxFragmentPresentation(FragmentContentId = Resource.Id.container)]
    [Register("org.nosplash.fragments.HomeFragment")]
    
    public class HomeFragment : MvxFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet();

            var view = this.BindingInflate(Resource.Layout.fragment_home, null);
            //var set = this.CreateBindingSet();
            //var tv = view.FindViewById<TextView>(Resource.Id.tv);
            //set.Bind(tv).For(v => v.Text).To(vm => vm.Prop);
            //set.Apply();

            return view;
        }
    }
}
