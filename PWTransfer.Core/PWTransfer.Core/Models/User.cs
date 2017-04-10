using System;
namespace PWTransfer.Core.Models
{
	public class User : BaseModel
	{
		public int UserId { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public double Balance { get; set; }
	}
}
