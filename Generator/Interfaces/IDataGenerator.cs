namespace Generator.Interfaces
{
    public interface IDataGenerator
    {
        JsonContent GenerateJson(string areaStr);
    }
}