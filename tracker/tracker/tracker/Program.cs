using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tracker.DataBase;
using tracker.QQueue;

namespace tracker
{
    class Program
    {
        private static OracleDB oracle;
        private static  Queue<Query> queryQueue;

        // one minute
        private const int THREAD_SLEEP_TIME = 60000;
        private static string DEFAULT_MOVE_TO_LOCATION = @"C:\Users\doarni\SouthavenFeed\html\data\";

        private static bool keepRunning = true;

        static void Main(string[] args)
        {
            // user specified location to move json files to
            if(args.Length != 0)
            {
                DEFAULT_MOVE_TO_LOCATION = args[0];
                Console.WriteLine(string.Format("DEFAULT_MOVE_TO_LOCATION set to = [{0}]", args[0]));
            }

            oracle = new OracleDB(LoadOracleConfig());
            queryQueue = new Queue<Query>();

            Console.WriteLine("Building queue");

            CompletedWorkQuery cwq = new CompletedWorkQuery(
                oracle, Properties.Settings.Default.ORACLE_COMPLETED_WORK, "completed_work.json", "completed_work"
                );

            CompletedWorkQuery cwqo = new CompletedWorkQuery(
                oracle, Properties.Settings.Default.ORACLE_COMPLETED_WORK_OTHER, "completed_work_other.json", "completed_work_other"
                );


            queryQueue.Enqueue(cwq);
            queryQueue.Enqueue(cwqo);

            Console.WriteLine("Complete.");

            Start();
            
        }

        public static void Start()
        {
            Console.WriteLine(string.Format("Time interval set to [{0} seconds | {1} minutes]",
                (THREAD_SLEEP_TIME / 1000).ToString(), ((THREAD_SLEEP_TIME / 1000) / 60).ToString()
                ));
            Console.WriteLine("Running application loop");

            oracle.OpenConnection();

            // https://stackoverflow.com/questions/177856/how-do-i-trap-ctrl-c-in-a-c-sharp-console-app

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
                oracle.CloseConnection();
            };

            while (Program.keepRunning)
            {

                foreach (Query q in queryQueue)
                {
                    Console.WriteLine("Executing: " + q.QueryName);

                    try
                    {
                        q.Get();
                        q.FormatResults();
                        q.WriteJSONFile();
                        Console.WriteLine(string.Format("Writing file: [{0}]", q.FileName));
                        MoveFile(q.FileName, DEFAULT_MOVE_TO_LOCATION + q.FileName);
                        Console.WriteLine(string.Format("Moving file to: [{0}]", DEFAULT_MOVE_TO_LOCATION + q.FileName));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }

                Thread.Sleep(THREAD_SLEEP_TIME);

            }

            oracle.CloseConnection();

        }

        private static void MoveFile(string file, string location)
        {
            File.Delete(location);
            File.Move(file, location);
        }

        private static OracleConfig LoadOracleConfig()
        {
            return new OracleConfig(
                Properties.Settings.Default.ORACLE_HOST,
                Properties.Settings.Default.ORACLE_SID,
                Properties.Settings.Default.ORACLE_PORT,
                Properties.Settings.Default.ORACLE_USERNAME,
                Properties.Settings.Default.ORACLE_PASSWORD
            );

        }
    }
}
