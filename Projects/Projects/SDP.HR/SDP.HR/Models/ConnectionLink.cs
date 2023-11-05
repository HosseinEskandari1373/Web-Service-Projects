
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataAccessLayer;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class ConnectionLink
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
        #region Name
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        #endregion
        #endregion
        #region Methods
        internal static ConnectionLink Select(int ConnectionLinkId)
        {
            try
            {
                return BaseInfo.ConnectionLinkList.Where(sl => sl.Id == ConnectionLinkId).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        internal static List<ConnectionLink> SelectAll()
        {
            List<ConnectionLink> result = new List<ConnectionLink>();
            List<DALParameter> parameters = new List<DALParameter>();
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_ConnectionLink_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<ConnectionLink>();
            return result;
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion

    }
}