using Android.Runtime;
using Android.Views;
using AndroidX.Preference;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvxNoSplash.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxNoSplash.Android.Fragments
{
    [Register("org.nosplash.fragments.HomeFragment")]
    
    public class HomeFragment : MvxFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet();

            var view = this.BindingInflate(Resource.Layout.fragment_home, null);

            return view;
        }
    }
}
