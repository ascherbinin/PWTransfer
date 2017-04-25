using PWTransfer.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using PWTransfer.Core.Contracts.Repositories;
using PWTransfer.Core.Models.Rest;

namespace PWTransfer.Core.Services
{
    class TransactionsDataService : BaseDataService, ITransactionsDataService
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionsDataService(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<Transaction> CreateTransaction(string userName, double amount)
        {
            return await _transactionsRepository.CreateTransaction(userName, amount);
        }

        public async Task<TransactionsList> GetTransactionsHistory()
        {
            return await _transactionsRepository.GetTransactionsHistory();
        }
    }
}
