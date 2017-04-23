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
using MvvmCross.Droid.Shared.Attributes;
using PWTransfer.Core.ViewModels;
using MvvmCross.Droid.Support.V4;

namespace PWTransfer.Droid
{
    [MvxFragmentAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Register("pwtransfer.android.MyListFragment")]
    public class MyListFragment : MvxFragment<MyListViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.ListView, container, false);
        }
    }
}