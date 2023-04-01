using System.IO;
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
                for (int i = 0; i < 100; i++)
                {
                    var gen = new Gen();
                    var json = gen.GenerateJson();
                    using (var httpClient = new HttpClient())
                    {
                        //var resp = httpClient.PostAsync(@"https://localhost:7050/adddiarea", json);
                        //Console.WriteLine(resp.Result);
                        File.WriteAllText(@"C:\Users\Admin\Documents\data.json", json.ReadAsStringAsync().Result);
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}