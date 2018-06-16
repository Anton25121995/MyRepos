using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;
using TestProject.Droid.Converters;
using static Android.Support.V4.Widget.SwipeRefreshLayout;

namespace TestProject.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), 2131296402, true)]
    [Register("App1.Android.Fragments.TableViewLayout")]
    public class TableFragment : BaseFragment<TableViewModel>
    {
        protected override int FragmentId => 2130968640;
        MvxListView listView;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            var swipe = view.FindViewById<SwipeRefreshLayout>(2131296426);

        #pragma warning disable CS0618 // Type or member is obsolete
            swipe.SetColorScheme(Android.Resource.Color.HoloBlueBright,
                Android.Resource.Color.HoloGreenLight,
                                       Android.Resource.Color.HoloOrangeLight,
                                       Android.Resource.Color.HoloRedLight);
        #pragma warning restore CS0618 // Type or member is obsolete

            return view;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Activity.OnBackPressed();
        }

        public override void OnPause()
        {
            base.OnPause();
        }
    }
}
