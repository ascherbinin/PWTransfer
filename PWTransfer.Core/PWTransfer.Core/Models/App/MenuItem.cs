using System;
using MvvmCross.Core.ViewModels;
using PWTransfer.Core.Utility;

namespace PWTransfer.Core.Models.App
{
	public class MenuItem : MvxViewModel
	{
		private bool _isSelected;

		public string Title { get; set; }
		public Type ViewModelType { get; set; }
		public MenuOption Option { get; set; }
		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				RaisePropertyChanged(() => IsSelected);
			}
		}
	}
}
