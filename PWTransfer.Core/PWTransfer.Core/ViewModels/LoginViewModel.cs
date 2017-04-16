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
        private readonly IUserRestService _userRestService;
        private readonly IUserDataService _userDataService;
        private readonly IUserRepository _userRepository;
        private string _token = "OTKEN";

        public IMvxCommand RegisterCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Token = _userDataService.Register("abra4", "kadabra4@mail.ru", "123456");
                });
            }
        }

        public LoginViewModel(IMvxMessenger messenger,
            IUserRestService userRestService,
            IUserRepository userRepository,
            IUserDataService userDataService
            ) : base(messenger)
        {
            _userRestService = userRestService;
            _userDataService = userDataService;
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
    }
}
