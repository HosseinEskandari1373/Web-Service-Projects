
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using DataAccessLayer;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class Gender
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
        #region EnName
        private string _EnName;
        public string EnName
        {
            get
            {
                return _EnName;
            }
            set
            {
                _EnName = value;
            }
        }
        #endregion
        #region FaName
        private string _FaName;
        public string FaName
        {
            get
            {
                return _FaName;
            }
            set
            {
                _FaName = value;
            }
        }
        #endregion
        #endregion
        #region Methods
        internal static Gender Select(int GenderId)
        {
            try
            {
                return BaseInfo.GenderList.Where(g => g.Id == GenderId).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        internal static List<Gender> SelectAll()
        {
            List<Gender> result = new List<Gender>();
            List<DALParameter> parameters = new List<DALParameter>();
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_Gender_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<Gender>();
            return result;
        }
        public override string ToString()
        {
            return FaName;
        }
        #endregion

    }
}