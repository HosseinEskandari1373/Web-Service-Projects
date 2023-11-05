
using DataAccessLayer;
using SDP.HR.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SDP.HR.Models
{
    public class LanguageInfo
    {
        #region Properties
        #region ForeignLanguageId
        private byte _ForeignLanguageId;
        public byte ForeignLanguageId
        {
            get
            {
                return _ForeignLanguageId;
            }
            set
            {
                _ForeignLanguageId = value;
            }
        }
        #endregion
        #region ForeignLanguage
        private ForeignLanguage _ForeignLanguageObj = null;
        public ForeignLanguage ForeignLanguage
        {
            get
            {
                if (_ForeignLanguageObj == null)
                    _ForeignLanguageObj = ForeignLanguage.Select(ForeignLanguageId);
                return _ForeignLanguageObj;
            }
        }
        #endregion
        #region ReadingSkillLevelId
        private byte _ReadingSkillLevelId;
        public byte ReadingSkillLevelId
        {
            get
            {
                return _ReadingSkillLevelId;
            }
            set
            {
                _ReadingSkillLevelId = value;
            }
        }
        #endregion
        #region ReadingSkillLevel
        private SkillLevel _ReadingSkillLevelObj = null;
        public SkillLevel ReadingSkillLevel
        {
            get
            {
                if (_ReadingSkillLevelObj == null)
                    _ReadingSkillLevelObj = SkillLevel.Select(ReadingSkillLevelId);
                return _ReadingSkillLevelObj;
            }
        }
        #endregion
        #region WritingSkillLevelId
        private byte _WritingSkillLevelId;
        public byte WritingSkillLevelId
        {
            get
            {
                return _WritingSkillLevelId;
            }
            set
            {
                _WritingSkillLevelId = value;
            }
        }
        #endregion
        #region WritingSkillLevel
        private SkillLevel _WritingSkillLevelObj = null;
        public SkillLevel WritingSkillLevel
        {
            get
            {
                if (_WritingSkillLevelObj == null)
                    _WritingSkillLevelObj = SkillLevel.Select(WritingSkillLevelId);
                return _WritingSkillLevelObj;
            }
        }
        #endregion
        #region SpeakingSkillLevelId
        private byte _SpeakingSkillLevelId;
        public byte SpeakingSkillLevelId
        {
            get
            {
                return _SpeakingSkillLevelId;
            }
            set
            {
                _SpeakingSkillLevelId = value;
            }
        }
        #endregion
        #region SpeakingSkillLevel
        private SkillLevel _SpeakingSkillLevelObj = null;
        public SkillLevel SpeakingSkillLevel
        {
            get
            {
                if (_SpeakingSkillLevelObj == null)
                    _SpeakingSkillLevelObj = SkillLevel.Select(SpeakingSkillLevelId);
                return _SpeakingSkillLevelObj;
            }
        }
        #endregion
        #endregion
        #region Methods
        public static List<LanguageInfo> SelectList(int personId)
        {
            List<DALParameter> parameters = new List<DALParameter>();
            parameters.Add(new DALParameter("@PersonId", personId));
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_LanguageInfo_SelList", DALAgent.enDBMethodOutput.MultipleValue, parameters);

            List<LanguageInfo> result = new List<LanguageInfo>();
            if (dalo.Value != null)
            {
                DataTable dt = (DataTable)dalo.Value;
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add((LanguageInfo)dr);
                }
            }
            return result;
        }
        public static explicit operator LanguageInfo(DataRow dr)
        {
            LanguageInfo obj = new LanguageInfo();
            System.Reflection.PropertyInfo[] propList = obj.GetType().GetProperties().Where(p => p.CanWrite).ToArray();
            foreach (DataColumn item in dr.Table.Columns)
            {
                if (propList.Where(pi => pi.Name == item.ColumnName).Count() == 0)
                    continue;
                try
                {
                    typeof(LanguageInfo).GetProperty(item.ColumnName).SetValue(obj, dr[item.ColumnName], null);
                }
                catch
                {
                }
            }
            return obj;
        }
        public override string ToString()
        {
            return this.ForeignLanguage.FaName;
        }
        #endregion
    }
}