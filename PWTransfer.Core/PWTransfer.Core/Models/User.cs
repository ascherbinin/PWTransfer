using System;
using Newtonsoft.Json;

namespace PWTransfer.Core.Models
{
	public class UserInfoToken
	{
		public int id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public int balance { get; set; }
	}

	public class User
	{
		public UserInfoToken user_info_token { get; set; }
	}


}

