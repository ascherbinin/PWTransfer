// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace PWTransfer.Core.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

    #endregion


    public static string GeneralSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
      }
    }

// <summary>
// Simply setup your settings once when it is initialized.
// </summary>
static ISettings AppSettings
{
	get
	{
		return CrossSettings.Current;
	}
}

#region Settings Constants

const string AccessTokenKey = "access_token";
static string AccessTokenDefault = string.Empty;

private const string UserNameKey = "username_key";
private static readonly string UserNameDefault = string.Empty;

private const string BalanceKey = "balance_key";
private static readonly double BalanceDefault = double.MinValue;

#endregion

public static string AccessToken
{
	get
	{
		return AppSettings.GetValueOrDefault<string>(AccessTokenKey, AccessTokenDefault);
	}
	set
	{
		AppSettings.AddOrUpdateValue<string>(AccessTokenKey, value);
	}
}

public static string UserName
{
	get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
	set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
}

public static double Balance
{
	get { return AppSettings.GetValueOrDefault<double>(BalanceKey, BalanceDefault); }
	set { AppSettings.AddOrUpdateValue<double>(BalanceKey, value);   }


  }
}