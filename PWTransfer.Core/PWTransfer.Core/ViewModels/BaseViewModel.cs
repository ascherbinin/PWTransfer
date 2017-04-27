using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.ViewModels
{
	public class BaseViewModel : MvxViewModel, IDisposable
	{
		protected IMvxMessenger Messenger;
		private bool _IsLoading = false;

		public bool IsLoading
		{
			get { return _IsLoading; }
			set
			{
				_IsLoading = value;
				RaisePropertyChanged(() => IsLoading);   
			}
		}

		public BaseViewModel(IMvxMessenger messenger)
		{
			Messenger = messenger;
		}

		public IMvxLanguageBinder TextSource =>
			new MvxLanguageBinder("", GetType().Name);

		protected async Task ReloadDataAsync()
		{
			try
			{
				await InitializeAsync();
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
		}

		protected virtual Task InitializeAsync()
		{
			return Task.FromResult(0);
		}

		public void Dispose()
		{
			Messenger = null;
		}

	}
}
