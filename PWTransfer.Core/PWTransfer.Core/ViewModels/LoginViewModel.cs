using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using PWTransfer.Core.Helpers;
using PWTransfer.Core.Models.Rest;
using PWTransfer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;

namespace PWTransfer.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private readonly IUserDataService _userDataService;
		private readonly IDialogService _dialogService;
        private string _token = "OTKEN";
        private string _email = "mutant-@live.ru";
        private string _password = "5757";
		private User _user;
        public IMvxCommand Register
        {
            get
            {
               return new MvxCommand(() => ShowViewModel<RegisterViewModel>());
            }
        }

        public IMvxCommand Login
        {
            get
            {
                return new MvxCommand(async() =>
                {
					IsLoading = true;
                    Token = await _userDataService.Login(Email, Password);
					_user = await _userDataService.GetSelfInfo();
					IsLoading = false;
                    if (_user != null && Token != null)
                    {
                        ShowViewModel<MainViewModel>();
                    }
                });
            }
        }

        public LoginViewModel(IMvxMessenger messenger,
		                      IDialogService dialogService,
            				  IUserDataService userDataService
            				 ) : base(messenger)
        {
			_dialogService = dialogService;
            _userDataService = userDataService;
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
    }
}
