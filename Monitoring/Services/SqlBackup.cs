

using Monitoring.DataAccessLayer;
using Monitoring.Interfaces;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Formats.Asn1;



namespace Monitoring.Services
{
    public static class SqlBackup
    {

        public static void backup_db(IResourceService database)
        {
            List<Monitoring.Models.Parameter> listOfParam = database.GetAllParameters();
            string backupPath1 = @"12332r";//create_backupPath();
            File.WriteAllText(backupPath1, String.Join(";", listOfParam));
            

            //using (var db = new DataContext())
            //{
            //    string backupPath = create_backupPath();
            //    var connection = db.Database.Connection as SqlConnection;
            //    connection.Open();
            //    if (connection != null && connection.State == System.Data.ConnectionState.Open)
            //    {
            //        Directory.CreateDirectory(backupPath);
            //        Console.WriteLine("backup");
            //        string query = $"BACKUP DATABASE [{connection.Database}] TO DISK = \'{backupPath}\\{DateTime.Today.Hour}_{DateTime.Today.Minute}.bak\'";
            //        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);
            //    }
            //    connection.Close();
            //}
        }
        static string create_backupPath()
        {
            string backupPath= "C:\\\\DB_BACKUPS";
            backupPath += $"\\[{DateTime.Today.Year.ToString()}]\\[{DateTime.Today.Month.ToString()}]\\[{DateTime.Today.Day.ToString()}]\\{DateTime.Today.Hour}_{DateTime.Today.Minute}.csv";


            return backupPath;
        }
    }
}
