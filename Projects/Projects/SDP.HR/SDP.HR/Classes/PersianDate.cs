using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace System
{
    public class PersianDate
    {
        #region Enums

        #endregion Enums

        #region Variables

        public static readonly PersianDate MaxValue = DateTime.MinValue;
        public static readonly PersianDate MinValue = DateTime.MaxValue;
        private PersianCalendar pc = new PersianCalendar();
        private DateTime currentDateTime;
        public static string[] MonthArray = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        #endregion Variables

        #region Properties

        #region Year

        public int Year
        {
            get
            {
                return pc.GetYear(currentDateTime);
            }
        }

        #endregion Year

        #region Month

        public int Month
        {
            get
            {
                return pc.GetMonth(currentDateTime);
            }
        }

        #endregion Month

        #region Day

        public int Day
        {
            get
            {
                return pc.GetDayOfMonth(currentDateTime);
            }
        }

        #endregion Day

        #region Hour

        public int Hour
        {
            get
            {
                return pc.GetHour(currentDateTime);
            }
        }

        #endregion Hour

        #region Minute

        public int Minute
        {
            get
            {
                return pc.GetMinute(currentDateTime);
            }
        }

        #endregion Minute

        #region Second

        public int Second
        {
            get
            {
                return pc.GetSecond(currentDateTime);
            }
        }

        #endregion Second

        #region ConnectionString

        private static string _ConnectionString = string.Empty;

        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        #endregion SqlConnection

        #region Now

        public static PersianDate Now
        {
            get
            {
                PersianDate result = null;
                if (ConnectionString.Length > 0)
                {
                    SqlConnection SqlConnection = new SqlConnection(ConnectionString);
                    if (SqlConnection.State != ConnectionState.Open)
                    {
                        try
                        {
                            SqlConnection.Open();
                        }
                        catch { }
                    }
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = SqlConnection;
                        cmd.CommandText = "Select GetDate();";
                        DateTime dt = (DateTime)cmd.ExecuteScalar();
                        result = dt;
                    }
                    catch
                    {
                    }
                }
                if (PersianDate.Equals(result, null)) // در مرحله قبل مقدار نگرفته
                {
                    DateTime dt = DateTime.Now;
                    result = dt;
                }
                return result;
            }
        }

        #endregion Now

        #region Time

        public Time Time
        {
            get
            {
                return new Time(Hour, Minute, Second);
            }
        }

        #endregion Time

        #endregion Properties

        #region Events

        #region Constructors

        public PersianDate(int year, int month, int day)
        {
            currentDateTime = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public PersianDate(int year, int month, int day, int hour, int minute, int second)
        {
            currentDateTime = pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        public PersianDate(string str, string delim = " ")
        {
            if (delim!=string.Empty)
            {
                try
                {
                    string[] arr = str.Split(delim.ToCharArray());
                    str = string.Empty;
                    str += arr[0].PadLeft(4,'0');
                    str += arr[1].PadLeft(2,'0');
                    str += arr[2].PadLeft(2, '0');
                }
                catch 
                {
                }
            }
            str = str.Replace(delim, string.Empty);
            int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
            try
            {
                year = int.Parse(str.Substring(0, 4));
            }
            catch
            {
            }
            try
            {
                month = int.Parse(str.Substring(4, 2));
            }
            catch
            {
            }
            try
            {
                day = int.Parse(str.Substring(6, 2));
            }
            catch
            {
            }
            try
            {
                hour = int.Parse(str.Substring(8, 2));
            }
            catch
            {
            }
            try
            {
                minute = int.Parse(str.Substring(10, 2));
            }
            catch
            {
            }
            try
            {
                second = int.Parse(str.Substring(12, 2));
            }
            catch
            {
            }
            currentDateTime = pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        public PersianDate(DateTime dt)
        {
            currentDateTime = dt;
        }

        #endregion Constructors

        #region Operators

        public static implicit operator DateTime(PersianDate pd)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(pd.Year, pd.Month, pd.Day, pd.Hour, pd.Minute, pd.Second, 0);
        }

        public static implicit operator PersianDate(DateTime dt)
        {
            return new PersianDate(dt);
        }

        #endregion Operators

        #endregion Events

        #region Methods

        #region Operators

        public static TimeSpan operator -(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime - pd2.currentDateTime;
        }

        public static PersianDate operator -(PersianDate d, TimeSpan t)
        {
            return d.currentDateTime - t;
        }

        public static bool operator !=(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime != pd2.currentDateTime;
        }

        public static PersianDate operator +(PersianDate d, TimeSpan t)
        {
            return d.currentDateTime + t;
        }

        public static bool operator <(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime < pd2.currentDateTime;
        }

        public static bool operator <=(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime <= pd2.currentDateTime;
        }

        public static bool operator ==(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime == pd2.currentDateTime;
        }

        public static bool operator >(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime > pd2.currentDateTime;
        }

        public static bool operator >=(PersianDate pd1, PersianDate pd2)
        {
            return pd1.currentDateTime >= pd2.currentDateTime;
        }

        #endregion Operators

        #region ToStringMethods

        public string ToDateString(string delim = "")
        {
            string result = Year.ToString("00") + delim + Month.ToString("00") + delim + Day.ToString("00");
            return result;
        }

        public string ToTimeString(string delim = "")
        {
            string result = Hour.ToString("00") + delim + Minute.ToString("00") + delim + Second.ToString("00");
            return result;
        }

        public string ToDateTimeString(string dateDelim = "", string timeDelim = "", string splitter = "")
        {
            string result = ToDateString(dateDelim);
            result += splitter;
            result += ToTimeString(timeDelim);
            return result;
        }

        public string To8DigitString()
        {
            string result = ToDateString();
            return result;
        }

        public string To14DigitString()
        {
            string result = ToDateTimeString();
            return result;
        }

        public override string ToString()
        {
            string result = ToDateTimeString("/", ":", " - ");
            return result;
        }

        #endregion ToStringMethods

        #region AddFunctions

        public PersianDate AddDays(int value)
        {
            return currentDateTime.AddDays(value);
        }

        public PersianDate AddMonths(int value)
        {
            return currentDateTime.AddMonths(value);
        }

        public PersianDate AddYears(int value)
        {
            return currentDateTime.AddYears(value);
        }

        public PersianDate AddHours(int value)
        {
            return currentDateTime.AddHours(value);
        }

        public PersianDate AddMinutes(int value)
        {
            return currentDateTime.AddMinutes(value);
        }

        public PersianDate AddSeconds(int value)
        {
            return currentDateTime.AddSeconds(value);
        }

        #endregion AddFunctions

        public bool IsValid()
        {
            bool result = false;
            try
            {
                PersianDate pd = new PersianDate(To8DigitString());
                result = true;
            }
            catch
            {
            }
            return result;
        }

        #endregion Methods
    }
}