using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class JobOpportunity
    {
        #region Properties
        #region Id
        private byte _Id;
        public byte Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        #endregion
        #region Title
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        #endregion
        #region Condition
        private string _Condition;
        public string Condition
        {
            get
            {
                return _Condition;
            }
            set
            {
                _Condition = value;
            }
        }
        #endregion
        #region Place
        private string _Place;
        public string Place
        {
            get
            {
                return _Place;
            }
            set
            {
                _Place = value;
            }
        }
        #endregion
        #region ExpireDate
        private string _ExpireDate = string.Empty;
        public string ExpireDate
        {
            get
            {
                return _ExpireDate;
            }
            set
            {
                try
                {
                    PersianDate pd = new PersianDate(value, "/");
                    _ExpireDate = pd.To8DigitString();
                }
                catch
                {
                }
            }
        }
        #endregion
        #endregion
        #region Methods
        public static List<JobOpportunity> SelectAll()
        {
            List<JobOpportunity> result = new List<JobOpportunity>();
            List<DALParameter> parameters = new List<DALParameter>();
            parameters.Add(new DALParameter("@ExpireDate", PersianDate.Now.To8DigitString()));
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_JobOpportunity_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<JobOpportunity>();
            return result;
        }
        #endregion
    }
}