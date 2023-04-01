

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
            Directory.CreateDirectory(backupPath);
            backupPath += $"{DateTime.Now.Hour}_{DateTime.Now.Minute}.csv";
            File.WriteAllText(backupPath, String.Join(";", listOfParam));
            //database.ClearParameters();
           
        }
        static string create_backupPath()
        {
            string backupPath= "C:\\\\DB_BACKUPS";
            backupPath += $"\\[{DateTime.Today.Year.ToString()}]\\[{DateTime.Today.Month.ToString()}]\\[{DateTime.Today.Day.ToString()}]\\";


            return backupPath;
        }
    }
}
