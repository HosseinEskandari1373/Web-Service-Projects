
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using DataAccessLayer;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class InstituteType
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
        internal static InstituteType Select(int InstituteTypeId)
        {
            try
            {
                return BaseInfo.InstituteTypeList.Where(g => g.Id == InstituteTypeId).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        internal static List<InstituteType> SelectAll()
        {
            List<InstituteType> result = new List<InstituteType>();
            List<DALParameter> parameters = new List<DALParameter>();
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_InstituteType_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<InstituteType>();
            return result;
        }
        #endregion

    }
}