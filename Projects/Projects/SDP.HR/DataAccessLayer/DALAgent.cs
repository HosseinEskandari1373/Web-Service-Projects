using System.Collections.Generic;


namespace DataAccessLayer
{
    public static class DALAgent
    {
        #region Enumerables

        public enum enDBLoginMode { WindowsAuthentication, DatabaseAuthentication };

        public enum enDBMethodOutput { MultipleValue, SingleValue, Nothing };

        public enum enDBMethodType { StoredProcedure, Query };

        #endregion Enumerables
        #region Methods

        public static void SetInstanceName(string InstanceName)
        {
            SQLAgent.InstanceName = InstanceName;
        }

        public static void SetLoginId(string loginId)
        {
            SQLAgent.LoginId = loginId;
        }

        public static void SetLoginPassword(string loginPassword)
        {
            SQLAgent.LoginPassword = loginPassword;
        }

        public static void SetLoginMode(enDBLoginMode loginMode)
        {
            SQLAgent.LoginMode = loginMode;
        }

        public static void SetDatabaseName(string dataBaseName)
        {
            SQLAgent.DatabaseName = dataBaseName;
        }

        public static DALOutput ExecuteQuery(string query, DALAgent.enDBMethodOutput methodOutput)
        {
            DALOutput result = SQLAgent.Execute(enDBMethodType.Query, methodOutput, query, null);
            return result;
        }

        public static DALOutput ExecuteProcedure(string procedureName, DALAgent.enDBMethodOutput methodOutput, List<DALParameter> lstParameters = null)
        {
            DALOutput result = SQLAgent.Execute(enDBMethodType.StoredProcedure, methodOutput, procedureName, lstParameters);
            return result;
        }

        public static List<DALParameter> GetParameters(string procedureName)
        {
            return SQLAgent.GetParameters(procedureName);
        }

        #endregion Methods
    }
}