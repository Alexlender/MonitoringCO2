using System.Net;

namespace Generator.Implementations
{
    static public class DownloadFile
    {
        static public void Download(string filename)
        {
            string url = @"http://localhost:7140/data.json";
            string path = @"C:\Users\Admin\Downloads\" + filename; // Путь для сохранения файла

            using (var client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
        }
    }
}
