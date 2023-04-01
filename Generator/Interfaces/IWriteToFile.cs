namespace Generator.Interfaces
{
    public interface IWriteToFile
    {
        void WriteTextToFile(string filePath, JsonContent text);
    }
}
