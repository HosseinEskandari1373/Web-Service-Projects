using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SQLAgent
    {
        #region Properties

        #region ConnectionString

        public static string ConnectionString
        {
            get
            {
                return string.Format(@"Data Source={0};Initial Catalog={1};Connect Timeout={2};{3}", InstanceName, DatabaseName, TimeOut, (LoginMode == DALAgent.enDBLoginMode.DatabaseAuthentication ? string.Format(@"User ID={0};Password={1}", LoginId, LoginPassword) : "Integrated Security=True"));
            }
        }

        #endregion ConnectionString

        #region InstanceName

        private static string _InstanceName;

        internal static string InstanceName
        {
            get
            {
                return _InstanceName;
            }
            set
            {
                _InstanceName = value;
            }
        }

        #endregion InstanceName

        #region DatabaseName

        private static string _DatabaseName;

        internal static string DatabaseName
        {
            get
            {
                return _DatabaseName;
            }
            set
            {
                                _DatabaseName = value;
            }
        }

        #endregion DatabaseName

        #region LoginMode

        private static DALAgent.enDBLoginMode _LoginMode;

        internal static DALAgent.enDBLoginMode LoginMode
        {
            get
            {
                return _LoginMode;
            }
            set
            {
                                _LoginMode = value;
            }
        }

        #endregion LoginMode

        #region LoginId

        private static string _LoginId;

        internal static string LoginId
        {
            get
            {
                return _LoginId;
            }
            set
            {
                _LoginId = value;
            }
        }

        #endregion LoginId

        #region LoginPassword

        private static string _LoginPassword;

        internal static string LoginPassword
        {
            get
            {
                return _LoginPassword;
            }
            set
            {
                                _LoginPassword = value;
            }
        }

        #endregion LoginPassword

        #region DBConnection

        #region TimeOut

        private static int _TimeOut = 60;

        internal static int TimeOut
        {
            get
            {
                return _TimeOut;
            }
            set
            {
                _TimeOut = value;
            }
        }

        #endregion TimeOut

        #endregion DBConnection

        #endregion Properties

        #region Methods

        public static DALOutput Execute(DALAgent.enDBMethodType methodType, DALAgent.enDBMethodOutput methodOutput, string commandText, List<DALParameter> lstParametes)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                con.Open();
            DALOutput result = new DALOutput();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = methodType == DALAgent.enDBMethodType.StoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            cmd.Connection = con;
            if (lstParametes != null)
                foreach (DALParameter dalp in lstParametes)
                {
                    cmd.Parameters.Add(dalp);
                }
  
            switch (methodOutput)
            {
                case DALAgent.enDBMethodOutput.MultipleValue:
                    cmd.CommandTimeout = 60;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    result.Value = dt.Columns.Count == 0 ? null : dt;
                    break;

                case DALAgent.enDBMethodOutput.SingleValue:
                    result.Value = cmd.ExecuteScalar();
                    break;

                case DALAgent.enDBMethodOutput.Nothing:
                    cmd.ExecuteNonQuery();
                    break;

                default:
                    break;
            }
            con.Close();
            return result;
        }

        public static List<DALParameter> GetParameters(string procedureName)
        {
            List<DALParameter> result = new List<DALParameter>();
            DALOutput dalo = new DALOutput();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = new SqlConnection(ConnectionString);
            if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                con.Open();
            cmd.Connection = con;
            SqlCommandBuilder.DeriveParameters(cmd);
            foreach (SqlParameter sp in cmd.Parameters)
            {
                result.Add(sp);
            }
            con.Close();
            return result;
        }

        public static void Backup(string path)
        {
            string query = string.Format(@"
BACKUP DATABASE [{0}] TO DISK = N'{1}' WITH COPY_ONLY, NOFORMAT, INIT, NAME = N'{0}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10

", DatabaseName, path);
            Execute(DALAgent.enDBMethodType.Query, DALAgent.enDBMethodOutput.Nothing, query, null);
        }

        //        public static void Restore(string path)
        //        {
        //            string query = string.Format(@"
        //SELECT
        //	   type,
        //       type_desc,
        //       name,
        //       physical_name
        //FROM   sys.database_files
        //
        //");
        //            string dbFile = "";
        //            DALOutput dalo = Execute(DALAgent.enDBMethodType.Query, DALAgent.enDBMethodOutput.MultipleValue, query, null);
        //            DataTable dt = (DataTable)dalo.Value;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                dbFile += string.Format(@" MOVE N'{0}' TO N'{1}', ", dr["name"].ToString(), dr["physical_name"].ToString());
        //            }
        //            query = string.Format(@"
        //EXEC msdb.dbo.sp_delete_database_backuphistory
        //  @database_name = N'{0}'
        //
        //DROP DATABASE [{0}]
        //
        //RESTORE DATABASE [{0}] FROM  DISK = N'{1}' WITH  FILE = 1, {2} NOUNLOAD, REPLACE, STATS = 10
        //ALTER DATABASE [{0}]
        //
        //SET enable_broker WITH
        //
        //ROLLBACK immediate;
        //", DatabaseName, path, dbFile);

        //            string dbName = DatabaseName;
        //            DatabaseName = "master";
        //            TimeOut = 600000;
        //            try
        //            {
        //                Execute(DALAgent.enDBMethodType.Query, DALAgent.enDBMethodOutput.Nothing, query, null);
        //            }
        //            catch
        //            {
        //                throw;
        //            }

        //            finally
        //            {
        //                SqlConnection.ClearAllPools();
        //                DatabaseName = dbName;
        //            }

        //        }
        
        #endregion Methods
    }
}