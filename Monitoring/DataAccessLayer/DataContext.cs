using Monitoring.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Monitoring.DataAccessLayer
{
    public class DataContext : System.Data.Entity.DbContext
    {
        public DataContext() : base("DataContext")
        {
           
        }

        public System.Data.Entity.DbSet<Parameter> Parameters { get; set; }
        public System.Data.Entity.DbSet<Area> Areas { get; set; }
        public System.Data.Entity.DbSet<AreaParam> AreaParams { get; set; }
        public System.Data.Entity.DbSet<Models.Type> Types { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
