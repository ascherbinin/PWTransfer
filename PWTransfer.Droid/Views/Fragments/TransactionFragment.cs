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
using MvvmCross.Binding.Droid.BindingContext;

namespace PWTransfer.Droid.Views.Fragments
{
    [MvxFragmentAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Register("PWTransfer.android.TransactionFragment")]
    public class TransactionFragment : MvxFragment<TransactionViewModel>
    {
        private bool _alreadyLoaded;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _alreadyLoaded = true;
            this.EnsureBindingContextIsSet(inflater);
            return this.BindingInflate(Resource.Layout.TransactionView, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }

        public override void OnResume()
        {
            if (!_alreadyLoaded) ViewModel.Start();
            base.OnResume();
        }

        public override void OnStop()
        {
            _alreadyLoaded = false;
            base.OnStop();
        }
    }
}