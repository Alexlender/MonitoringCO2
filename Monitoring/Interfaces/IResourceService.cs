using System.Resources;
using Monitoring.Models;

namespace Monitoring.Interfaces
{
    public interface IResourceService
    {
        void AddParameter(Parameter Parameter);

        void AddParametersFromFile(string str);

        void AddDiarea(Diarea diarea);

        void AddArea(Area Area);

        public List<Area> GetAreas();
        List<Parameter> GetAllParameters();

    }
}
