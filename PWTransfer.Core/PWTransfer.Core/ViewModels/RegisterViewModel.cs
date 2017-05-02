using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Helpers;

namespace PWTransfer.Core.ViewModels
{
    public class RegisterViewModel : BaseViewModel, IRegisterViewModel
    {
        private readonly IUserDataService _userDataService;
        private readonly IDialogService _dialogService;
        private string _token = "TOKEN";
        private string _username = "";
        private string _email = "";
        private string _password = "";

        public RegisterViewModel(IMvxMessenger messenger,
            IDialogService dialogService,
            IUserDataService userDataService
            ) : base(messenger)
        {
            _userDataService = userDataService;
            _dialogService = dialogService;
        }

        public IMvxCommand Register
        {
            get
            {
                return new MvxCommand(async () =>
                {
					IsLoading = true;
                    Token = await _userDataService.Register(Username, Password, Email);
					IsLoading = false;
                    if (Token != null)
                    {
                        await
                        _dialogService.ShowAlertAsync
                        (TextSource.GetText("CongratulationsMessage"),
                         TextSource.GetText("CongratulationsTitle"),
                         TextSource.GetText("CongratulationsOkButton"),
                         delegate { ShowViewModel<UsersViewModel>(); });
                    }
                });
            }
        }

        public override async void Start()
        {
            base.Start();
            IsLoading = false;
            await ReloadDataAsync();
        }

        protected override Task InitializeAsync()
        {
            return Task.Run(() =>
            {

            });
        }

        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                RaisePropertyChanged(() => Token);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

    }
}
