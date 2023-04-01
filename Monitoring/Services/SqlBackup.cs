

using Monitoring.DataAccessLayer;
using Monitoring.Interfaces;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Formats.Asn1;
using Monitoring.Services;



namespace Monitoring.Services
{
    public static class SqlBackup
    {


        public static void backup_db(IResourceService database)
        {
            List<Monitoring.Models.Parameter> listOfParam = database.GetAllParameters();
            string backupPath = create_backupPath();


            using (var db = new DataContext())
            {
                //SqlResourceService.GetAllParameters();

                var connection = db.Database.Connection as SqlConnection;
                connection.Open();
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    Directory.CreateDirectory(backupPath);
                    Console.WriteLine("backup");
                    string query = $"BACKUP DATABASE [{connection.Database}] TO DISK = \'{backupPath}\\{DateTime.Now.Hour}_{DateTime.Now.Minute}.bak\'";
                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);
                }
                connection.Close();
            }
            //using (var streamWriter = new StreamWriter(@".\Res_mapping.csv", false, Encoding.GetEncoding(1251)))
            //{
            //    var columns = Area.Param.Cast<DataColumn>();
            //    streamWriter.WriteLine(string.Join(";", columns));

            //    foreach (DataRow row in Adress_for_mapping.Rows)
            //    {
            //        streamWriter.WriteLine(string.Join(";", row.ItemArray));
            //    }
            //}
        }
        static string create_backupPath()
        {
            string backupPath = "C:\\\\DB_BACKUPS";
            backupPath += $"\\[{DateTime.Today.Year.ToString()}]\\[{DateTime.Today.Month.ToString()}]\\[{DateTime.Today.Day.ToString()}]";


            return backupPath;
        }

    }
}
