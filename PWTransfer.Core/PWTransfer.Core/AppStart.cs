using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using PWTransfer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            ShowViewModel<LoginViewModel>();
        }
    }
}
