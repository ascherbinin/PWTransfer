using System;
namespace PWTransfer.Core.Models
{
	public class Transaction : BaseModel
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public string UserName { get; set; }

		public double Amount { get; set; }

		public double Balance { get; set; }
	}
}
