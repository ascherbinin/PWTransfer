using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using PWTransfer.Core.Models.Rest;

namespace PWTransfer.Core.ViewModels
{
    public class UsersViewModel : BaseViewModel, ISearchUsersViewModel
    {
        //private readonly ISavedJourneyDataService _savedJourneyDataService;
        private readonly IUserDataService _userDataService;

        private ObservableCollection<RemoteUser> _users;

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    Users = (await _userDataService.GetUsers(" ")).ToObservableCollection();
                });
            }
        }

        public MvxCommand CreateTransactionCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<MyListViewModel>();
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
           
            Users = (await _userDataService.GetUsers(" ")).ToObservableCollection();

        }
    }
}
