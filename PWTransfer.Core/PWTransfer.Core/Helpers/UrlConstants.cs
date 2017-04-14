using System;
namespace PWTransfer.Core.Utility
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
			return _apiUrl + "/users";
		}

		public static string LoginURL()
		{
			return _apiUrl + "/sessions/create";
		}

		public static string TransactionURL()
		{
			return _apiUrl + "/api/protected/transactions";
		}

		public static string UserInfoURL()
		{
			return _apiUrl + "/api/protected/user-info";
		}

		public static string UsersURL()
		{
			return _apiUrl + "/api/protected/users/list\n";
		}
	}
}
