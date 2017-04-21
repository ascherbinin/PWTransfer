using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using PWTransfer.Core.Contracts.ViewModels;
using PWTransfer.Core.ViewModels;

namespace PWTransfer.Core.ViewModels
{
	public class MainViewModel : MvxViewModel, IMainViewModel
	{
		private readonly Lazy<SearchUsersViewModel> _searchUsersViewModel;
		private readonly Lazy<TransactionViewModel> _transactionViewModel;
		private readonly Lazy<SettingsViewModel> _settingsViewModel;

		public SearchUsersViewModel SearchJourneyViewModel => _searchUsersViewModel.Value;

		public TransactionViewModel SavedJourneysViewModel => _transactionViewModel.Value;

		public SettingsViewModel SettingsViewModel => _settingsViewModel.Value;

		public MainViewModel()
		{
			_searchUsersViewModel = new Lazy<SearchUsersViewModel>(Mvx.IocConstruct<SearchUsersViewModel>);
			_transactionViewModel = new Lazy<TransactionViewModel>(Mvx.IocConstruct<TransactionViewModel>);
			_settingsViewModel = new Lazy<SettingsViewModel>(Mvx.IocConstruct<SettingsViewModel>);
		}

		public void ShowMenu()
		{
			ShowViewModel<MenuViewModel>();
		}

		public void ShowSearchJourneys()
		{
			ShowViewModel<SearchUsersViewModel>();
		}
	}
}
