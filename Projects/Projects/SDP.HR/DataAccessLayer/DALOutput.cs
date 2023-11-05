using System;

namespace DataAccessLayer
{
    public class DALOutput
    {
        #region Properties

        #region Value

        private Object _Value;

        public Object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        #endregion Value

        #endregion Properties
    }
}