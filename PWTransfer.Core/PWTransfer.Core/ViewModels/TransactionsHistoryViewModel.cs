﻿using PWTransfer.Core.Contracts.ViewModels;
using PWTransfer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Models.Rest;
using MvvmCross.Core.ViewModels;

namespace PWTransfer.Core.ViewModels
{
	public class TransactionsHistoryViewModel : BaseViewModel, ITransactionsHistoryViewModel
	{
		private readonly ITransactionsDataService _transactionsDataService;
		private readonly MvxSubscriptionToken _token;

		private Trans_Token[] _transactions;

		public TransactionsHistoryViewModel(IMvxMessenger messenger,
											ITransactionsDataService transactionsDataService) : base(messenger)
		{
			_transactionsDataService = transactionsDataService;
			_token = messenger.Subscribe<ReceiveNewTransactionMessage>(OnReloadData);
		}

		public MvxCommand ReloadDataCommand => new MvxCommand(async () =>
															 {
																 Transactions = (await _transactionsDataService.GetTransactionsHistory()).trans_token;
															 });

		public MvxCommand CreateTransactionCommand => new MvxCommand(() =>
															{
																ShowViewModel<UsersViewModel>();
															});


		public Trans_Token[] Transactions
		{
			get
			{
				return _transactions;
			}
			set
			{
				_transactions = value;
				RaisePropertyChanged(() => Transactions);
			}
		}


		public override async void Start()
		{
			base.Start();
			await ReloadDataAsync();
		}

		protected override async Task InitializeAsync()
		{
			Transactions = (await _transactionsDataService.GetTransactionsHistory()).trans_token;
		}

		private async void OnReloadData(ReceiveNewTransactionMessage message)
		{
			await ReloadDataAsync();
		}

	}
}
