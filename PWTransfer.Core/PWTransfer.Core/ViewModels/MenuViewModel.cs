using System;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Models.App;
using PWTransfer.Core.Utility;
using PWTransfer.Core.ViewModels;

namespace PWTransfer.Core.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{
		public MvxCommand<MenuItem> MenuItemSelectCommand => new MvxCommand<MenuItem>(OnMenuEntrySelect);
		public ObservableCollection<MenuItem> MenuItems { get; }

		public event EventHandler CloseMenu;

		public MenuViewModel(IMvxMessenger messenger) : base(messenger)
		{
			MenuItems = new ObservableCollection<MenuItem>();
			CreateMenuItems();
		}

		private void CreateMenuItems()
		{
			MenuItems.Add(new MenuItem
			{
				Title = "Users",
				ViewModelType = typeof(SearchUsersViewModel),
				Option = MenuOption.Users,
				IsSelected = true
			});

			MenuItems.Add(new MenuItem
			{
				Title = "Transactions",
				ViewModelType = typeof(TransactionViewModel),
				Option = MenuOption.Transactions,
				IsSelected = false
			});

			MenuItems.Add(new MenuItem
			{
				Title = "Settings",
				ViewModelType = typeof(SettingsViewModel),
				Option = MenuOption.Settings,
				IsSelected = false
			});
		}

		private void OnMenuEntrySelect(MenuItem item)
		{
			ShowViewModel(item.ViewModelType);
			RaiseCloseMenu();
		}

		private void RaiseCloseMenu()
		{
			CloseMenu?.Invoke(this, EventArgs.Empty);
		}
	}
}
}
