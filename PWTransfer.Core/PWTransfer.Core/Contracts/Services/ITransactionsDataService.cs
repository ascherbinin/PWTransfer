using PWTransfer.Core.Models;
using PWTransfer.Core.Models.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Contracts.Services
{
    public interface ITransactionsDataService
    {
        Task<IEnumerable<Transaction>> GetTransactionsHistory();

        Task<Transaction> CreateTransaction(string userName, double amount);
    }
}
