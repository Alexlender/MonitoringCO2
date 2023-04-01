using System.IO;
using Generator.Interfaces;
namespace Generator.Implementations
{
    public class WriteToFile : IWriteToFile
    {
        public void WriteTextToFile(string filePath, string text)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
                //string filePath = "path/to/my/file.txt";
                //string text = "Hello, world!";
            }
        }
    }
}