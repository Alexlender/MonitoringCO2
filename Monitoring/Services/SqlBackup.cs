

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
                var connection = db.Database.Connection as SqlConnection;
                string backupPath = create_backupPath();
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    string query = $"BACKUP DATABASE [{connection.Database}] TO DISK = \'{backupPath}\'";
                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);
                }
                
            }
        }
        static string create_backupPath()
        {
            string backupPath= ".\\\\DataContextBackup";
            backupPath += $"\\[{DateTime.Today.Year.ToString()}]\\[{DateTime.Today.Month.ToString()}]\\[{DateTime.Today.Day.ToString()}]";


            return backupPath;
        }
    }
}
