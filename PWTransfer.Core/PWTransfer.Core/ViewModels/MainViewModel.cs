using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using PWTransfer.Core.Contracts.ViewModels;
using PWTransfer.Core.ViewModels;
using System.Collections.Generic;

namespace PWTransfer.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        readonly Type[] _menuItemTypes = {
            typeof(MyListViewModel),
            typeof(UsersViewModel),
        };

        public IEnumerable<string> MenuItems { get; private set; } = new[] { "MyList", "Users" };

        public void ShowDefaultMenuItem()
        {
            NavigateTo(0);
        }

        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }

    public class MenuItem : Tuple<string, Type>
    {
        public MenuItem(string displayName, Type viewModelType)
            : base(displayName, viewModelType)
        { }

        public string DisplayName
        {
            get { return Item1; }
        }

        public Type ViewModelType
        {
            get { return Item2; }
        }
    }
}
