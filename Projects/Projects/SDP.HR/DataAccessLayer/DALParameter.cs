using System.Data;

namespace DataAccessLayer
{
    public class DALParameter
    {
        #region Variables

        #endregion Variables

        #region Properties

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

        #endregion Name

        #region Value

        private object _Value;

        public object Value
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

        #region Direction

        private ParameterDirection _Direction;

        public ParameterDirection Direction
        {
            get
            {
                return _Direction;
            }
            set
            {
                _Direction = value;
            }
        }

        #endregion Direction

        #region DBType

        private DbType _DBType;

        public DbType DBType
        {
            get
            {
                return _DBType;
            }
            set
            {
                _DBType = value;
            }
        }

        #endregion DBType

        #region IsDataTable

        private bool _IsDataTable;

        public bool IsDataTable
        {
            get
            {
                return _IsDataTable;
            }
            set
            {
                _IsDataTable = value;
            }
        }

        #endregion IsDataTable

        #region IsNative

        private bool _IsNative;

        public bool IsNative
        {
            get
            {
                return _IsNative;
            }
            set
            {
                _IsNative = value;
            }
        }

        #endregion IsNative

        #endregion Properties

        #region Events

        public DALParameter(string name, object value, bool isDataTable = false)
        {
            Name = name;
            Value = value;
            IsDataTable = isDataTable;
        }

        public DALParameter()
        {
        }

        #endregion Events

        #region Methods

        public static implicit operator System.Data.SqlClient.SqlParameter(DALParameter dalp)
        {
            System.Data.SqlClient.SqlParameter result = new System.Data.SqlClient.SqlParameter();
            result.ParameterName = dalp.Name;
            result.Value = dalp.Value;
            result.Direction = dalp.Direction;
            result.DbType = dalp.DBType;
            if (dalp.IsDataTable)
            {
                result.SqlDbType = SqlDbType.Structured;
            }
            if (dalp.IsNative)
            {
                result.SqlDbType = SqlDbType.NVarChar;
            }
            return result;
        }

        public static implicit operator DALParameter(System.Data.SqlClient.SqlParameter sp)
        {
            DALParameter result = new DALParameter();
            result.Name = sp.ParameterName;
            result.Value = sp.Value;
            result.Direction = sp.Direction;
            result.DBType = sp.DbType;
            result.IsDataTable = sp.SqlDbType == SqlDbType.Structured;
            return result;
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion Methods
    }
}