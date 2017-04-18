﻿using System;
using Newtonsoft.Json;

namespace PWTransfer.Core.Models
{
	//public class UserInfoToken
	//{
	//	public int id { get; set; }
	//	public string name { get; set; }
	//	public string email { get; set; }
	//	public double balance { get; set; }
	//}

	//public class User
	//{
	//	[JsonProperty("user_info_token")]
	//	public UserInfoToken user_info_token { get; set; }

	//	public User()
	//	{
	//		user_info_token.id = 0;
	//		user_info_token.name = "";
	//		user_info_token.email = "";
	//		user_info_token.balance = 0.0;
	//	}
	//}
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

