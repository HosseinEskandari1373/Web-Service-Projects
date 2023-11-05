using SDP.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDP.HR.Classes
{
    public static class BaseInfo
    {
        #region GenderList
        private static List<Gender> _GenderList=new List<Gender>();
        public static List<Gender> GenderList
        {
            get
            {
                if (_GenderList.Count==0)
                    _GenderList = Gender.SelectAll();
                return _GenderList;
            }
            set
            {
                _GenderList = value;
            }
        }
        #endregion
        #region SkillLevelList
        private static List<SkillLevel> _SkillLevelList = new List<SkillLevel>();
        public static List<SkillLevel> SkillLevelList
        {
            get
            {
                if (_SkillLevelList.Count == 0)
                    _SkillLevelList = SkillLevel.SelectAll();
                return _SkillLevelList;
            }
            set
            {
                _SkillLevelList = value;
            }
        }
        #endregion
        #region ConnectionLinkList
        private static List<ConnectionLink> _ConnectionLinkList = new List<ConnectionLink>();
        public static List<ConnectionLink> ConnectionLinkList
        {
            get
            {
                if (_ConnectionLinkList.Count == 0)
                    _ConnectionLinkList = ConnectionLink.SelectAll();
                return _ConnectionLinkList;
            }
            set
            {
                _ConnectionLinkList = value;
            }
        }
        #endregion
        #region ReligionList
        private static List<Religion> _ReligionList = new List<Religion>();
        public static List<Religion> ReligionList
        {
            get
            {
                if (_ReligionList.Count == 0)
                    _ReligionList = Religion.SelectAll();
                return _ReligionList;
            }
            set
            {
                _ReligionList = value;
            }
        }
        #endregion
        #region MilitaryStatusList
        private static List<MilitaryStatus> _MilitaryStatusList = new List<MilitaryStatus>();
        public static List<MilitaryStatus> MilitaryStatusList
        {
            get
            {
                if (_MilitaryStatusList.Count == 0)
                    _MilitaryStatusList = MilitaryStatus.SelectAll();
                return _MilitaryStatusList;
            }
            set
            {
                _MilitaryStatusList = value;
            }
        }
        #endregion
        #region MaritalStatusList
        private static List<MaritalStatus> _MaritalStatusList = new List<MaritalStatus>();
        public static List<MaritalStatus> MaritalStatusList
        {
            get
            {
                if (_MaritalStatusList.Count == 0)
                    _MaritalStatusList = MaritalStatus.SelectAll();
                return _MaritalStatusList;
            }
            set
            {
                _MaritalStatusList = value;
            }
        }
        #endregion
        #region EducationDegreeList
        private static List<EducationDegree> _EducationDegreeList = new List<EducationDegree>();
        public static List<EducationDegree> EducationDegreeList
        {
            get
            {
                if (_EducationDegreeList.Count == 0)
                    _EducationDegreeList = EducationDegree.SelectAll();
                return _EducationDegreeList;
            }
            set
            {
                _EducationDegreeList = value;
            }
        }
        #endregion
        #region ForeignLanguageList
        private static List<ForeignLanguage> _ForeignLanguageList = new List<ForeignLanguage>();
        public static List<ForeignLanguage> ForeignLanguageList
        {
            get
            {
                if (_ForeignLanguageList.Count == 0)
                    _ForeignLanguageList = ForeignLanguage.SelectAll();
                return _ForeignLanguageList;
            }
            set
            {
                _ForeignLanguageList = value;
            }
        }
        #endregion
        #region JobOpportunityList
        private static DateTime _JobOpportunityList_LastUpdate = DateTime.Now;
        private static List<JobOpportunity> _JobOpportunityList = new List<JobOpportunity>();
        public static List<JobOpportunity> JobOpportunityList
        {
            get
            {
                if (_JobOpportunityList.Count == 0 || _JobOpportunityList_LastUpdate <DateTime.Now.AddMinutes(-10))
                {
                    _JobOpportunityList = JobOpportunity.SelectAll();
                    _JobOpportunityList_LastUpdate = DateTime.Now;
                }

                return _JobOpportunityList;
            }
            set
            {
                _JobOpportunityList = value;
            }
        }
        #endregion
        #region InstituteTypeList
        private static List<InstituteType> _InstituteTypeList = new List<InstituteType>();
        public static List<InstituteType> InstituteTypeList
        {
            get
            {
                if (_InstituteTypeList.Count == 0)
                    _InstituteTypeList = InstituteType.SelectAll();
                return _InstituteTypeList;
            }
            set
            {
                _InstituteTypeList = value;
            }
        }
        #endregion
        #region ProvinceList
        private static List<Province> _ProvinceList = new List<Province>();
        public static List<Province> ProvinceList
        {
            get
            {
                if (_ProvinceList.Count == 0)
                    _ProvinceList = Province.SelectAll();
                return _ProvinceList;
            }
            set
            {
                _ProvinceList = value;
            }
        }
        #endregion
    }
}