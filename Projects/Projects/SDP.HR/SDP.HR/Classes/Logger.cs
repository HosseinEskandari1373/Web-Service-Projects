using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SDP.HR.Classes
{
    internal class LogLine
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        internal string ToLine(string splitter)
        {
            string result = string.Empty;
            PropertyInfo[] prop = typeof(LogLine).GetProperties();
            string[] arr = new string[prop.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    arr[i] = prop[i].GetValue(this).ToString().Replace("\"", "\"" + "\"");
                }
                catch
                {
                    arr[i] = string.Empty;
                }
            }
            result = string.Join(string.Concat("\"",splitter,"\""), arr);
            result = string.Concat("\"", result, "\"");
            return result;

        }
    }

    public static class Logger
    {
        #region Variables
        private static string Splitter = ",";
        private enum enLogType { Warning, Error, Success, Info }
        #endregion
        #region Properties     
        #region HeaderLine
        private static string _HeaderLine = string.Empty;
        public static string HeaderLine
        {
            get
            {
                if (_HeaderLine == string.Empty)
                {
                    PropertyInfo[] prop = typeof(LogLine).GetProperties();
                    string[] arr = new string[prop.Length];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = prop[i].Name;
                    }
                    _HeaderLine = string.Join(Splitter, arr);
                }
                return _HeaderLine;
            }
            set
            {
                _HeaderLine = value;
            }
        }
        #endregion
        #endregion
        #region Methods
        private static void WriteMessage(enLogType logType, string message, Exception exception=null)
        {
            LogLine ll = new LogLine();
            PersianDate pd = PersianDate.Now;
            ll.Date = pd.ToDateString("/");
            ll.Time = pd.Time.ToString();
            ll.Type = logType.ToString();
            ll.Message = message;
            if (exception != null)
            {
                ll.Exception = exception.Message;
                ll.StackTrace = exception.StackTrace == null ? string.Empty : exception.StackTrace;
                if (exception.InnerException != null)
                    ll.InnerException = exception.InnerException.Message;
            }
            string logFileAddress = Path.Combine(AppInfo.LogPath, pd.ToDateString(" - ").Substring(0, 9), pd.ToDateString(".") + ".csv");
            if (!File.Exists(logFileAddress))
            {
                if (!Directory.Exists(Path.GetDirectoryName(logFileAddress)))
                    Directory.CreateDirectory(Path.GetDirectoryName(logFileAddress));
                File.AppendAllText(logFileAddress, HeaderLine + "\r\n");
            }
            string line = ll.ToLine(Splitter);
            File.AppendAllText(logFileAddress, line + "\r\n");
        }
        public static void WriteError(string message = "", Exception exception = null)
        {
            WriteMessage(enLogType.Error, message, exception);
        }
        public static void WriteSuccess(string message = "")
        {
            WriteMessage(enLogType.Success, message);
        }
        public static void WriteWarning(string message = "")
        {
            WriteMessage(enLogType.Warning, message);
        }
        public static void WriteInfo(string message = "")
        {
            WriteMessage(enLogType.Info, message);
        }

        #endregion
    }
}