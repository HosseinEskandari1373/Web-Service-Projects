using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SDP.HR.Classes
{
    public class AppInfo
    {
        #region Properties
        #region DatabaseName
        private static string _DatabaseName=string.Empty;
        public static string DatabaseName
        {
            get
            {
                if (_DatabaseName == string.Empty)
                    _DatabaseName = GetAppSetting("DatabaseName");
                return _DatabaseName;
            }
        }
        #endregion
        #region InstanceName
        private static string _InstanceName = string.Empty;
        public static string InstanceName
        {
            get
            {
                if (_InstanceName == string.Empty)
                    _InstanceName = GetAppSetting("InstanceName");
                return _InstanceName;
            }
        }
        #endregion
        #region MaxCVSize_MB
        private static short _MaxCVSize_MB = short.MinValue;
        public static short MaxCVSize_MB
        {
            get
            {
                if (_MaxCVSize_MB == short.MinValue)
                    _MaxCVSize_MB = short.Parse(GetAppSetting("MaxCVSize_MB"));
                return _MaxCVSize_MB;
            }
        }
        #endregion
        #region MaxImageSize_MB
        private static short _MaxImageSize_MB = short.MinValue;
        public static short MaxImageSize_MB
        {
            get
            {
                if (_MaxImageSize_MB == short.MinValue)
                    _MaxImageSize_MB = short.Parse(GetAppSetting("MaxImageSize_MB"));
                return _MaxImageSize_MB;
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
                    _LogPath = GetAppSetting("LogPath");
                return _LogPath;
            }
        }
        #endregion
        #endregion
        #region Methods
        private static string GetAppSetting(string str)
        {
            try
            {
                return ConfigurationManager.AppSettings[str];
            }
            catch
            {
                return string.Empty;
            }
        } 
        #endregion
    }
}