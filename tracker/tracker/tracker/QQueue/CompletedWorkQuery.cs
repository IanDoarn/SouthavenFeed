using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracker.DataBase;

namespace tracker.QQueue
{

    class CompletedWorkQuery : Query
    {
        private DataTable results;
        private OracleDB connection;
        private Exception error;
        private List<Employee> employees;

        private string queryString;
        private string fileName;
        private string queryName;

        public override string FileName { get { return fileName; } }
        public override string QueryName { get { return queryName; } }

        public Exception Error { get { return error; } }

        public CompletedWorkQuery(OracleDB connection, string queryString, string fileName, string queryName)
        {
            this.connection = connection;
            this.queryString = queryString;
            this.fileName = fileName;
            this.queryName = queryName;
        }

        public override bool Get()
        {
            try
            {
                results = connection.execute(queryString);
                return true;
            }
            catch(Exception er)
            {
                this.error = er;
                return false;
            }
        }

        public override void FormatResults()
        {
            employees = new List<Employee>();
            
            foreach(DataRow row in results.Rows)
            {
                employees.Add(new Employee(
                    row["EMPLOYEE"].ToString(),
                    Convert.ToInt32(row["KIT_INBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["PIECE_INBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["INSTRUMENT_INBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["PUTAWAY_TRANSFER"].ToString()),
                    Convert.ToInt32(row["KIT_BUILD_TRANSFER"].ToString()),
                    Convert.ToInt32(row["OUTBOUND_TRANSFER"].ToString()),
                    Convert.ToInt32(row["OTHER_TRANSFER"].ToString()),
                    Convert.ToDouble(row["TOTAL_PRODUCTIVITY"].ToString())
                    ));
            }
        }

        public override void WriteJSONFile()
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(employees, Formatting.Indented));
        }
    }
}
