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
        List<Parameter> GetAllParameters();

    }
}
