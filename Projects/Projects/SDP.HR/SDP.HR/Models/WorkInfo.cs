
using DataAccessLayer;
using SDP.HR.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SDP.HR.Models
{
    public class WorkInfo
    {
        #region Properties
        #region CompanyName
        private string _CompanyName;
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        #endregion
        #region Post
        private string _Post;
        public string Post
        {
            get
            {
                return _Post;
            }
            set
            {
                _Post = value;
            }
        }
        #endregion
        #region Duties
        private string _Duties;
        public string Duties
        {
            get
            {
                return _Duties;
            }
            set
            {
                _Duties = value;
            }
        }
        #endregion
        #region StartDate
        private string _StartDate = string.Empty;
        public string StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                try
                {
                    PersianDate pd = new PersianDate(value, "/");
                    _StartDate = pd.To8DigitString();
                }
                catch
                {
                }
            }
        }
        #endregion
        #region EndDate
        private string _EndDate = string.Empty;
        public string EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                try
                {
                    PersianDate pd = new PersianDate(value, "/");
                    _EndDate = pd.To8DigitString();
                }
                catch
                {
                }
            }
        }
        #endregion
        #region LeaveReason
        private string _LeaveReason;
        public string LeaveReason
        {
            get
            {
                return _LeaveReason;
            }
            set
            {
                _LeaveReason = value;
            }
        }
        #endregion
        #region LastSalary
        private int _LastSalary;
        public int LastSalary
        {
            get
            {
                return _LastSalary;
            }
            set
            {
                _LastSalary = value;
            }
        }
        #endregion
        #region PhoneNo
        private string _PhoneNo;
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }
        #endregion
        #region Methods
        public static List<WorkInfo> SelectList(int personId)
        {
            List<DALParameter> parameters = new List<DALParameter>();
            parameters.Add(new DALParameter("@PersonId", personId));
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_WorkInfo_SelList", DALAgent.enDBMethodOutput.MultipleValue, parameters);

            List<WorkInfo> result = new List<WorkInfo>();
            if (dalo.Value != null)
            {
                DataTable dt = (DataTable)dalo.Value;
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add((WorkInfo)dr);
                }
            }
            return result;
        }
        public static explicit operator WorkInfo(DataRow dr)
        {
            WorkInfo obj = new WorkInfo();
            System.Reflection.PropertyInfo[] propList = obj.GetType().GetProperties().Where(p => p.CanWrite).ToArray();
            foreach (DataColumn item in dr.Table.Columns)
            {
                if (propList.Where(pi => pi.Name == item.ColumnName).Count() == 0)
                    continue;
                try
                {
                    typeof(WorkInfo).GetProperty(item.ColumnName).SetValue(obj, dr[item.ColumnName], null);
                }
                catch
                {
                }
            }
            return obj;
        }
        public override string ToString()
        {
            return CompanyName;
        }
        #endregion
        #endregion
    }
}