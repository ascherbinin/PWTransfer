using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using System;
using System.Threading.Tasks;

namespace PWTransfer.Core.ViewModels
{
	public class TransactionViewModel : BaseViewModel, ITransactionViewModel
    {
        private readonly ITransactionsDataService _transactionsDataService;
        private readonly IDialogService _dialogService;
        private int _amount;
        private string _name;

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    RaisePropertyChanged(() => Amount);
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        public MvxCommand ConfirmTransactionComment
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    await
                      _dialogService.ShowAlertAsync
                      ("TO {Name}",
                       "Confirm transaction",
                       "OK",
                       null);
                });
            }
        }

        public TransactionViewModel(IMvxMessenger messenger,
                                    IDialogService dialogService,
                                    ITransactionsDataService transactionsDataService) : base(messenger)
        {
            _transactionsDataService = transactionsDataService;
            _dialogService = dialogService;
        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        public void Init(string name)
        {
            _name = name;
        }
    }
}
