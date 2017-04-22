using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using PWTransfer.Core.ViewModels;
using MvvmCross.Droid.Support.V4;

namespace PWTransfer.Droid.Views.Fragments
{
    [MvxFragmentAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Register("PWTransfer.android.UsersFragment")]
    public class UsersFragment : MvxFragment<UsersViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.UsersView, container, false);
        }
    }
}