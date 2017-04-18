using System;
namespace PWTransfer.Core.Helpers
{
	public static class UrlConstants
	{
		private static string _apiUrl = "http://193.124.114.46:3001";

		public static string BaseApiURL()
		{
			return _apiUrl;
		}

		public static string RegisterUserURL()
		{
			return "/users";
		}

		public static string LoginURL()
		{
			return "/sessions/create";
		}

		public static string TransactionURL()
		{
			return _apiUrl + "/api/protected/transactions";
		}

		public static string UserInfoURL()
		{
			return "/api/protected/user-info";
		}

		public static string UsersURL()
		{
			return _apiUrl + "/api/protected/users/list\n";
		}
	}
}
