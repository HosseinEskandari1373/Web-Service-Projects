using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using DataAccessLayer;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class MilitaryStatus
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

        internal static MilitaryStatus Select(byte? MilitaryStatusId)
        {
            if (!MilitaryStatusId.HasValue)
            {
                return null;
            }
            try
            {
                return BaseInfo.MilitaryStatusList.Where(g => g.Id == MilitaryStatusId.Value).FirstOrDefault();
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
        internal static List<MilitaryStatus> SelectAll()
        {
            List<MilitaryStatus> result = new List<MilitaryStatus>();
            List<DALParameter> parameters = new List<DALParameter>();
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_MilitaryStatus_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<MilitaryStatus>();
            return result;
        }
        public override string ToString()
        {
            return FaName;
        }
        #endregion
    }
}
