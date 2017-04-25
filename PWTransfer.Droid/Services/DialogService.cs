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
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform;
using System.Threading.Tasks;
using PWTransfer.Core.Contracts.Services;

namespace PWTransfer.Droid.Services
{
    public class DialogService : IDialogService
    {
        protected Activity CurrentActivity =>
            Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        public async Task ShowAlertAsync(string message,
            string title, string buttonText, Action callback)
        {
            await Task.Run(() =>
            {
                Alert(message, title, buttonText, callback);
            });
        }

        private void Alert(string message, string title, string okButton, Action callback)
        {
            Application.SynchronizationContext.Post(ignored =>
            {
                var builder = new AlertDialog.Builder(CurrentActivity);
                builder.SetIconAttribute
                    (Android.Resource.Attribute.AlertDialogIcon);
                builder.SetTitle(title);
                builder.SetMessage(message);
                if (!Equals(callback, null))
                    builder.SetNegativeButton(okButton, (sender, e) => { callback(); });
                else
                    builder.SetNegativeButton(okButton, (sender, e) => { });
                builder.Show();
            }, null);
        }
    }
}