using System.Resources;
using Monitoring.Models;

namespace Monitoring.Interfaces
{
    public interface IResourceService
    {
        void AddParameter(Parameter Parameter);

        void AddParametersFromFile(string str);

        public List<float> GetParamsValueFromArea(Area area, Models.Type type);

        public List<DateTime> GetParamsDatesFromArea(Area area, Models.Type type);
        public Area GetArea(string name);
        void AddDiarea(Diarea diarea);

        void AddArea(Area Area);

        void AddParameterToArea(AreaParam ap);

        void ClearParameters();

        public List<Area> GetAreas();
        List<Parameter> GetAllParameters();

        public List<Models.Type> GetParamsTypesByArea(Area area);

    }
}
