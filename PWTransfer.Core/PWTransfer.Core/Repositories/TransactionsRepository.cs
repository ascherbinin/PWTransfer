using PWTransfer.Core.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWTransfer.Core.Models;
using PWTransfer.Core.Helpers;
using PWTransfer.Core.Models.Rest;

namespace PWTransfer.Core.Repositories
{
    public class TransactionsRepository : BaseRepository, ITransactionsRepository
    {
        public async Task<Transaction> CreateTransaction(string userName, double amount)
        {
            try
            {
                var transaction = await PostAsync<Transaction>(UrlConstants.TransactionURL(), new TransactionData { name = userName, amount = amount});
                return transaction;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TransactionsList>> GetTransactionsHistory()
        {
            try
            {
                return await GetAsync<List<Transaction>>(UrlConstants.TransactionURL());
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
