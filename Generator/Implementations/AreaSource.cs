using Generator.Interfaces;

namespace Generator.Implementations
{
    static public class AreaSource
    {
        static async public void AddSource(string areaStr)
        {
            var dataGenerator = new Worker(areaStr);
            await dataGenerator.Run();
        }
    }
}
