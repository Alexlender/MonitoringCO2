using Generator.Implementations;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace Generator
{
    public class Worker
    {
        private readonly HttpClient _httpClient;

        public Worker()
        {
            _httpClient = new HttpClient();
        }

        public async Task Run()
        {
            while (true)
            {
                var gen = new Gen();
                JsonContent json = gen.GenerateJson();
                //var response = await _httpClient.PostAsync("http://localhost/adddata", content);
                var write = new WriteToFile();
                Console.WriteLine(json);
                write.WriteTextToFile(@"C:\Users\Admin\Documents\data.json", json);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}