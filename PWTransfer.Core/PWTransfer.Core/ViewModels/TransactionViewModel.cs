using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Contracts.ViewModels;
using System;
using System.Threading.Tasks;
using PWTransfer.Core.Models.Rest;

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

        public MvxCommand ConfirmTransactionCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {

					await
					_dialogService.ShowAlertAsync(
						(String.Format("Want to transfer money to {0}", Name)),
						 "Confirm transaction",
						 "OK",
						 async() => { 
							Transaction trans = await _transactionsDataService.CreateTransaction(Name, Amount);
							 if (trans != null)
							 {
								 await _dialogService.ShowToastAsync(String.Format("Transaction complete! Balance: {0}", trans.trans_token.balance));
								 var message = new ReceiveNewTransactionMessage(this);
							 	 Messenger.Publish(message);
							 }
							 else
							 {
								 await _dialogService.ShowToastAsync("Transaction ERROR!");
							 }
					     });
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
