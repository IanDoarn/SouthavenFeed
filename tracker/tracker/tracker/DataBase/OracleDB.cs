using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace tracker.DataBase
{
    public class OracleDB : IDatabaseConnection
    {
        private OracleConnection connection = null;
        private OracleConfig oracleConfig;
        private string ConnectionString;
        private bool isConnected = false;

        public OracleConnection ConnectionObj { get { return connection; } set { this.connection = value; } }

        public bool IsConnected() { return isConnected; }

        public OracleDB(OracleConfig oracleConfig)
        {
            this.oracleConfig = oracleConfig;
            this.ConnectionString = this.oracleConfig.ConnectionString();
            connection = new OracleConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
                isConnected = true;
            }
            catch (OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
                isConnected = false;
            }
            catch (OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TestConnection()
        {
            // Close connection incase it is already open
            if (isConnected)
            {
                CloseConnection();
            }

            // Test connection
            try
            {
                OpenConnection();
                CloseConnection();
                return true;
            }
            catch (OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable execute(string query, bool ensureReturn=true)
        {
            if (!isConnected)
            {
                throw new Exception("No connection to the database is currently made.");
            }

            try
            {
                DataTable dt = new DataTable();

                OracleCommand cmd = new OracleCommand(query);

                cmd.CommandType = CommandType.Text;

                cmd.Connection = connection;

                using (OracleDataAdapter adapter = new OracleDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                if (ensureReturn)
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }

                    throw new Exception(string.Format("No data returned from query. QUERY: [{0}]", query));
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }

                    return null;
                }
            }
            catch(OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message + " QUERY = " + query, ex.ErrorCode);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
