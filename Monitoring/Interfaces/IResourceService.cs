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

        void AddParameterToArea(AreaParam ap);

        public List<Area> GetAreas();
        List<Parameter> GetAllParameters();

        public List<Models.Type> GetParamsTypesByArea(Area area);

    }
}
