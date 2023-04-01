using Monitoring.Interfaces;
using Monitoring.Models;
using Monitoring.DataAccessLayer;

namespace Monitoring.Services
{
    public class SqlResourceService : IResourceService
    {
        private DataContext db = new DataContext();

        public void AddDiarea(Diarea diarea)
        {
            if (db.Areas.AsEnumerable().Where(a => a.Name == diarea.area.Name).ToList().Count == 1)
                foreach (var p in diarea.parameters)
                {
                    p.area = diarea.area;
                    db.Parameters.Add(p);
                }
            else
            {
                db.Areas.Add(new Area() { Name = "StrongMachine", Description = "Какое-то описание" });
            }
        }

        public void AddParameter(Parameter parameter)
        {
            db.Parameters.Add(parameter);
            db.SaveChangesAsync();
        }

        public void AddParametersFromFile(string str)
        {

            Console.WriteLine(str);
        }
        public List<Parameter> GetAllParameters()
        {
            return db.Parameters.ToList();
        }

        public List<Area> GetAreas()
        {
            return db.Areas.ToList();
        }

        /*public List<Area> GetParamsByArea(Area area)
        {
            //return db.AreaParams.AsEnumerable<AreaParam>().Select().ToList<Area>();
        }
        */
    }
}
