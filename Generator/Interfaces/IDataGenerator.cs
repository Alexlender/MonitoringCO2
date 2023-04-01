namespace Generator.Interfaces
{
    public interface IDataGenerator
    {
        Task<string> GenerateJson();
    }
}