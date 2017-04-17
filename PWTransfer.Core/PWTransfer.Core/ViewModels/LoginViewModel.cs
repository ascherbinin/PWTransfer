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

namespace PWTransfer.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private readonly IUserRepository _userRepository;
        private string _token = "OTKEN";
        private string _email = "";
        private string _password = "";

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
                return new MvxCommand(() =>
                {
                    Token = _userRepository.Login(Email, Password).Result;
                });
            }
        }

        public LoginViewModel(IMvxMessenger messenger,
            IUserRestService userRestService,
            IUserRepository userRepository,
            IUserDataService userDataService
            ) : base(messenger)
        {
            _userRepository = userRepository;
        }

        public override async void Start()
        {
            base.Start();
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
