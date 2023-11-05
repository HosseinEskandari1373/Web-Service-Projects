
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using DataAccessLayer;
using SDP.HR.Classes;

namespace SDP.HR.Models
{
    public class City
    {
        #region Properties
        #region ProvinceId
        private short _ProvinceId;
        public short ProvinceId
        {
            get
            {
                return _ProvinceId;
            }
            set
            {
                _ProvinceId = value;
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
        internal static List<City> SelectByProvinceId(short ProvinceId)
        {
            List<City> result = new List<City>();
            List<DALParameter> parameters = new List<DALParameter>();
            parameters.Add(new DALParameter("@ProvinceId", ProvinceId));
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_City_SelByProvinceId", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
            result = dt.ToList<City>();
            return result;
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion

    }
}