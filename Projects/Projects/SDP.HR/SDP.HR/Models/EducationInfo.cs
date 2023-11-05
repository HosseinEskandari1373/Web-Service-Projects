
using DataAccessLayer;
using SDP.HR.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SDP.HR.Models
{
    public class EducationInfo
    {
        #region Properties
        #region EducationDegreeId
        private byte _EducationDegreeId;
        public byte EducationDegreeId
        {
            get
            {
                return _EducationDegreeId;
            }
            set
            {
                _EducationDegreeId = value;
            }
        }
        #endregion
        #region Field
        private string _Field;
        public string Field
        {
            get
            {
                return _Field;
            }
            set
            {
                _Field = value;
            }
        }
        #endregion
        #region SubField
        private string _SubField;
        public string SubField
        {
            get
            {
                return _SubField;
            }
            set
            {
                _SubField = value;
            }
        }
        #endregion
        #region InstituteTypeId
        private int? _InstituteTypeId;
        public int? InstituteTypeId
        {
            get
            {
                return _InstituteTypeId;
            }
            set
            {
                _InstituteTypeId = value;
            }
        }
        #endregion
        #region Institute
        private string _Institute;
        public string Institute
        {
            get
            {
                return _Institute;
            }
            set
            {
                _Institute = value;
            }
        }
        #endregion
        #region EndYear
        private short? _EndYear;
        public short? EndYear
        {
            get
            {
                return _EndYear;
            }
            set
            {
                _EndYear = value;
            }
        }
        #endregion
        #region GPA
        private float? _GPA;
        public float? GPA
        {
            get
            {
                return _GPA;
            }
            set
            {
                _GPA = value;
            }
        }
        #endregion
        #region IsFinished
        private bool _IsFinished;
        public bool IsFinished
        {
            get
            {
                return _IsFinished;
            }
            set
            {
                _IsFinished = value;
            }
        }
        #endregion

        #endregion
        #region Methods
        public static List<EducationInfo> SelectList(int personId)
        {
            List<DALParameter> parameters = new List<DALParameter>();
            parameters.Add(new DALParameter("@PersonId", personId));
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_EducationInfo_SelList", DALAgent.enDBMethodOutput.MultipleValue, parameters);

            List<EducationInfo> result = new List<EducationInfo>();
            if (dalo.Value != null)
            {
                DataTable dt = (DataTable)dalo.Value;
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add((EducationInfo)dr);
                }
            }
            return result;
        }
        public static explicit operator EducationInfo(DataRow dr)
        {
            EducationInfo obj = new EducationInfo();
            System.Reflection.PropertyInfo[] propList = obj.GetType().GetProperties().Where(p => p.CanWrite).ToArray();
            foreach (DataColumn item in dr.Table.Columns)
            {
                if (propList.Where(pi => pi.Name == item.ColumnName).Count() == 0)
                    continue;
                try
                {
                    typeof(EducationInfo).GetProperty(item.ColumnName).SetValue(obj, dr[item.ColumnName], null);
                }
                catch
                {
                }
            }
            return obj;
        }
        #endregion
    }
}