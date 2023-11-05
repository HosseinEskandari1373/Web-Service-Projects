using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using DataAccessLayer;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class MaritalStatus
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

        internal static MaritalStatus Select(int MaritalStatusId)
        {
            try
            {
                return BaseInfo.MaritalStatusList.Where(g => g.Id == MaritalStatusId).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion
        #endregion
        #region Methods
        internal static List<MaritalStatus> SelectAll()
        {
            List<MaritalStatus> result = new List<MaritalStatus>();
            List<DALParameter> parameters = new List<DALParameter>();
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_MaritalStatus_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<MaritalStatus>();
            return result;
        }
        public override string ToString()
        {
            return FaName;
        }
        #endregion

    }
}