namespace System
{
    public class Time
    {
        #region Variables

        #endregion Variables

        #region Properties

        #region Hour

        private int _Hour;

        public int Hour
        {
            get
            {
                return _Hour;
            }
            set
            {
                _Hour = value;
            }
        }

        #endregion Hour

        #region Minute

        private int _Minute;

        public int Minute
        {
            get
            {
                return _Minute;
            }
            set
            {
                _Minute = value;
            }
        }

        #endregion Minute

        #region Second

        private int _Second;

        public int Second
        {
            get
            {
                return _Second;
            }
            set
            {
                _Second = value;
            }
        }

        #endregion Second

        #endregion Properties

        #region Events

        #region Constructors

        public Time(int totalSeconds)
        {
            Hour = (totalSeconds / 3600) % 24;
            Minute = ((totalSeconds - Hour * 3600) / 60) % 60;
            Second = totalSeconds % 60;
        }
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public Time(string str, string delim)
        {
            str = str.Replace(delim, string.Empty);
            try
            {
                Hour = int.Parse(str.Substring(0, 2));
            }
            catch { }
            try
            {
                Minute = int.Parse(str.Substring(2, 2));
            }
            catch { }
            try
            {
                Second = int.Parse(str.Substring(4, 2));
            }
            catch { }
        }

        #endregion Constructors

        #endregion Events

        #region Methods

        public string To4DigitString(string delim = "")
        {
            string result = string.Empty;
            result = Hour.ToString("00") + delim + Minute.ToString("00");
            return result;
        }

        public string To6DigitString(string delim = "")
        {
            string result = string.Empty;
            result = To4DigitString(delim) + delim + Second.ToString("00");

            return result;
        }

        public override string ToString()
        {
            return To6DigitString(":");
        }

        public bool IsValid()
        {
            return Hour >= 0 && Hour < 24 && Minute >= 0 && Minute < 60 && Second >= 0 && Second < 60;
        }

        public Time AddHours(int dif)
        {
            DateTime dt = new DateTime(2000, 1, 1, Hour, Minute, Second);
            dt = dt.AddHours(dif);
            PersianDate pd = dt;
            Time result = pd.Time;
            return result;
        }
        public Time AddMinutes(int dif)
        {
            DateTime dt = new DateTime(2000, 1, 1, Hour, Minute, Second);
            dt = dt.AddMinutes(dif);
            PersianDate pd = dt;
            Time result = pd.Time;
            return result;
        }
        public Time AddSeconds(int dif)
        {
            DateTime dt = new DateTime(2000, 1, 1, Hour, Minute, Second);
            dt = dt.AddSeconds(dif);
            PersianDate pd = dt;
            Time result = pd.Time;
            return result;
        }
        #endregion Methods
    }
}