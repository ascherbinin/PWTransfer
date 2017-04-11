using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTransfer.Core.Utility
{
    public static class Settings
    {
        /// <summary>
        /// Simply setup your settings once when it is initialized.
        /// </summary>
        //static ISettings AppSettings
        //{
        //    get
        //    {
        //        return CrossSettings.Current;
        //    }
        //}

        #region Settings Constants

        const string AccessTokenKey = "access_token";
        static string AccessTokenDefault = string.Empty;

        #endregion

        //public static string AccessToken
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault<string>(AccessTokenKey, AccessTokenDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue<string>(AccessTokenKey, value);
        //    }
        //}

    }
}