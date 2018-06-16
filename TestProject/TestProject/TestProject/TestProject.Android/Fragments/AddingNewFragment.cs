using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views.Attributes;
using TestProject.Core.ViewModels;

namespace TestProject.Droid.Fragments
{
    //[MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    //[Register("App1.Android.Fragments.ItemViewLayout")]
    //public class AddingNewFragment : BaseFragment<ItemViewModel>
    //{
    //    public override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);

    //        // Create your fragment here
    //    }

    //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    //    {
    //        // Use this to return your custom view for this Fragment
    //        // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

    //        return base.OnCreateView(inflater, container, savedInstanceState);
    //    }
    //}
}