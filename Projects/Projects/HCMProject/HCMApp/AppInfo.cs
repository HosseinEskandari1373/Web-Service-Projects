using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMApp
{
    public class AppInfo
    {
        #region SleepTime
        private static int _SleepTime = int.MinValue;
        public static int SleepTime
        {
            get
            {
                if (_SleepTime == int.MinValue)
                    _SleepTime = int.Parse(ConfigurationManager.AppSettings["SleepTime"]);
                return _SleepTime;
            }
        }
        #endregion
        #region LogPath
        private static string _LogPath = string.Empty;
        public static string LogPath
        {
            get
            {
                if (_LogPath == string.Empty)
                {
                    _LogPath = ConfigurationManager.AppSettings["LogPath"];
                    if (!_LogPath.EndsWith(@"\"))
                    {
                        _LogPath += @"\";
                    }
                }
                return _LogPath;
            }
        }
        #endregion
        #region ServiceMode
        private static bool? _ServiceMode = null;
        public static bool ServiceMode
        {
            get
            {
                if (_ServiceMode == null)
                {
                    _ServiceMode = bool.Parse(ConfigurationManager.AppSettings["ServiceMode"]);
                }
                return _ServiceMode.Value;
            }
        }
        #endregion
        #region SecureLoginId
        private static string SecureLoginId = @"7Ob7Mv31pBqhYLtXpfCBxQ==";
        private static string _LoginId = string.Empty;
        public static string LoginId
        {
            get
            {
                if (_LoginId == string.Empty)
                {
                    _LoginId = SecurityAgent.DecryptString(SecureLoginId);
                }
                return _LoginId;
            }
        }
        #endregion
        #region SecureLoginPassword
        private static string SecureLoginPassword = @"3ChY3F6Ng1ZmmGpx3rhlMw==";
        private static string _LoginPassword = string.Empty;
        public static string LoginPassword
        {
            get
            {
                if (_LoginPassword == string.Empty)
                {
                    _LoginPassword = SecurityAgent.DecryptString(SecureLoginPassword);
                }
                return _LoginPassword;
            }
        }
        #endregion
        #region DBServer
        private static string _DBServer = string.Empty;
        public static string DBServer
        {
            get
            {
                if (_DBServer == string.Empty)
                    _DBServer = ConfigurationManager.AppSettings["DBServer"];
                return _DBServer;
            }
        }
        #endregion
        #region DBName
        private static string _DBName = string.Empty;
        public static string DBName
        {
            get
            {
                if (_DBName == string.Empty)
                    _DBName = ConfigurationManager.AppSettings["DBName"];
                return _DBName;
            }
        }
        #endregion
        #region DBConnection
        private static string _ConnectionString = string.Empty;
        public static string ConnectionString
        {
            get
            {
                if (_ConnectionString == string.Empty)
                {
                    _ConnectionString = $@"data source={DBServer};initial catalog={DBName};Integrated Security=False;user id={SecurityAgent.DecryptString(SecureLoginId)};password={SecurityAgent.DecryptString(SecureLoginPassword)};MultipleActiveResultSets=True;App=EntityFramework";
                }
                return _ConnectionString;

            }
        }
        #endregion
    }
}
