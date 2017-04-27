using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using PWTransfer.Core.Models.Rest;
using System.Windows.Input;

namespace PWTransfer.Core.ViewModels
{
    public class UsersViewModel : BaseViewModel, ISearchUsersViewModel
    {
        private readonly IUserDataService _userDataService;
        private string _filter = " ";
        private string _selectedName;

        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    RaisePropertyChanged(() => Filter);
                }
            }
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                if (value != _selectedName)
                {
                    _selectedName = value;

                    RaisePropertyChanged(() => SelectedName);
                }
            }
        }

        private ObservableCollection<RemoteUser> _users;

        private MvxCommand<RemoteUser> _userSelectedCommand;
        public IMvxCommand UserSelectedCommand
        {
            get { return _userSelectedCommand ?? (_userSelectedCommand = new MvxCommand<RemoteUser>(OnUserSelected)); }
        }

        void OnUserSelected(RemoteUser selectedUser)
        {
            ShowViewModel<TransactionViewModel>(new { name = selectedUser.name });
        }

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    IsLoading = true;
                    Users = (await _userDataService.GetUsers(Filter)).ToObservableCollection();
                    IsLoading = false;
                });
            }
        }

         public ObservableCollection<RemoteUser> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public UsersViewModel(IMvxMessenger messenger,
            IUserDataService userDataService) : base(messenger)
        {
            _userDataService = userDataService;

            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            //Messenger.Subscribe<CurrencyChangedMessage>(async message => await ReloadDataAsync());
        }


        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            IsLoading = true;
            Users = (await _userDataService.GetUsers(Filter)).ToObservableCollection();
            IsLoading = false;
        }
    }
}
