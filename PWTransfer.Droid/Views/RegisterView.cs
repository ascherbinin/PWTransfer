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
using MvvmCross.Droid.Views;
using PWTransfer.Core.ViewModels;

namespace PWTransfer.Droid.Views
{
    [Activity(Label = "Register")]
    public class RegisterView : MvxActivity
    {
        public new RegisterViewModel ViewModel
        {
            get { return (RegisterViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.RegisterView);
        }
    }
}
