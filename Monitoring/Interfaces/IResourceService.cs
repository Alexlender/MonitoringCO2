using System.Resources;
using Monitoring.Models;

namespace Monitoring.Interfaces
{
    public interface IResourceService
    {
        void AddParameter(Parameter Parameter);

        List<Parameter> GetAllParameters();

    }
}
