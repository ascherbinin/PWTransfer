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
        private readonly IUserRepository _userRepository;
        private string _token = "OTKEN";

        public IMvxCommand RegisterCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var token = await _userRestService.Register("abra4", "kadabra4@mail.ru", "123456");

                    Token = token.id_token;
                });
            }
        }

        public LoginViewModel(IMvxMessenger messenger,
            IUserRestService userRestService,
            IUserRepository userRepository
            ) : base(messenger)
        {
            _userRestService = userRestService;
            _userRepository = userRepository;
        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override Task InitializeAsync()
        {
            _userRepository.ShowMsg("msg");
            return Task.Run(() =>
            {

            });
        }

        public async Task<Token> Register()
        {
            var content = await _userRestService.Register("abra3", "kadabra3@mail.ru", "123456");
            return content;
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
