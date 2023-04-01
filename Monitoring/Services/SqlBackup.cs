

using Monitoring.DataAccessLayer;
using System.Data.Entity;
using System.Data.SqlClient;


namespace Monitoring.Services
{
    public static class SqlBackup
    {
        public static void backup_db()
        {
          
            using (var db = new DataContext())
            {
                string backupPath = create_backupPath();
                var connection = db.Database.Connection as SqlConnection;
                connection.Open();
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    Directory.CreateDirectory(backupPath);
                    Console.WriteLine("backup");
                    string query = $"BACKUP DATABASE [{connection.Database}] TO DISK = \'{backupPath}\\{DateTime.Today.Minute}_{DateTime.Today.Second}.bak\'";
                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);
                }
                connection.Close();
            }
        }
        static string create_backupPath()
        {
            string backupPath= "C:\\\\DB_BACKUPS";
            backupPath += $"\\[{DateTime.Today.Year.ToString()}]\\[{DateTime.Today.Month.ToString()}]\\[{DateTime.Today.Day.ToString()}]";


            return backupPath;
        }
    }
}
