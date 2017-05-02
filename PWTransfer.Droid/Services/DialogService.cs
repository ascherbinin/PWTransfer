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
		private static string _message;

		public async Task ShowAlertAsync(string message,
			string title, string buttonText, Action callback)
		{
			await Task.Run(() =>
			{
				Alert(message, title, buttonText, callback);
			});
		}

		public async Task ShowToastAsync(string message)
		{
			_message = message;
			await Task.Run(() =>
			{
				ShowToast(message);
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
				{
					builder.SetPositiveButton(okButton, (sender, e) => { callback(); });
					builder.SetNegativeButton("Cancel", (sender, e) => { });
				}
				else
				{
					builder.SetNegativeButton(okButton, (sender, e) => { });
				}
				builder.Show();
			}, null);
		}

		public Task<bool?> ShowAsync(string message, string title, string OKButtonContent, string CancelButtonContent)
		{
			var tcs = new TaskCompletionSource<bool?>();

			var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
			AlertDialog.Builder builder = new AlertDialog.Builder(mvxTopActivity.Activity);
			builder.SetTitle(title)
				   .SetMessage(message)
				   .SetCancelable(false)
				   .SetPositiveButton(OKButtonContent, (s, args) =>
					{
						tcs.SetResult(true);
					})
				   .SetNegativeButton(CancelButtonContent, (s, args) =>
				   {
					   tcs.SetResult(false);
				   });

			builder.Create().Show();
			return tcs.Task;
		}

		private void ShowToast(string message)
		{
			CurrentActivity.RunOnUiThread(mMessageShow);

		}

		private Java.Lang.Runnable mMessageShow = new Java.Lang.Runnable(() =>
		{

			Toast.MakeText(Application.Context, _message, ToastLength.Long).Show();
		});

	}
																		
}