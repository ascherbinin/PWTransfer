using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.ViewModels
{
    public class LoginViewModel: BaseViewModel, ILoginViewModel
    {
        private readonly IUserRestService _userRestService;

        public IMvxCommand RegisterCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _userRestService.Register("abra", "kadabra@mail.ru", "123456");
                });
            }
        }

        public LoginViewModel(IMvxMessenger messenger,
            IUserRestService userRestService) : base(messenger)
        {
            _userRestService = userRestService;
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
    }
}
