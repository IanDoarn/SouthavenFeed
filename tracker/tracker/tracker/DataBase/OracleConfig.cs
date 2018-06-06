using Oracle.ManagedDataAccess.Client;

namespace tracker.DataBase
{
    public class OracleConfig : IConfig
    {
        private string host;
        private string sid;
        private string port;
        private string user;
        private string pass;

        private OracleConnectionStringBuilder ocstrb = new OracleConnectionStringBuilder();

        public string Host { get { return host; } set { this.host = value; } }
        public string SID {  get { return sid; } set { this.sid = value; } }
        public string Port {  get { return port; } set { this.port = value; } }
        public string User { get { return user; } set { this.user = value; } }

        public string Password { set { this.pass = value; } }

        public string DataSource { get { return string.Format("(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})))", host, port, sid); } }
        public string ConnectionString() { return connectionString(); }        

        public OracleConfig(string host, string sid, string port, string user, string pass)
        {
            this.host = host;
            this.sid = sid;
            this.port = port;
            this.user = user;
            this.pass = pass;        
        }

        private string connectionString()
        {
            string basic = string.Format("Data Source={0};User Id={1};Password={2}", DataSource, User, pass);

            ocstrb.UserID = user;
            ocstrb.DataSource = string.Format(@"{0}:{1}/{2}", host, port, sid);
            //ocstrb.DataSource = this.DataSource;
            ocstrb.Password = pass;

            return ocstrb.ToString();
        }
          
    }
}
