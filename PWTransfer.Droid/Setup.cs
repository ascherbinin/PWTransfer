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
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using PWTransfer.Core;
using MvvmCross.Platform.Platform;
using PWTransfer.Core.Utility;

namespace PWTransfer.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            //Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new MyDebugTrace();
        }
    }
}