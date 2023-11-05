using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDP.HR.Classes
{
    public class ControlError
    {
        #region ControlId
        private string _ControlId;
        public string ControlId
        {
            get
            {
                return _ControlId;
            }
            set
            {
                _ControlId = value;
            }
        }
        #endregion
        #region ErrorText
        private string _ErrorText;
        public string ErrorText
        {
            get
            {
                return _ErrorText;
            }
            set
            {
                _ErrorText = value;
            }
        }
        #endregion
    }

}