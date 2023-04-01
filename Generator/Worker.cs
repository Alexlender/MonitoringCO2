namespace Generator
{
    using Generator.Implementations;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class Worker
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _uri;

        public Worker(Uri uri)
        {
            _uri = uri;
            _httpClient = new HttpClient();
        }

        public async Task Run()
        {
            while (true)
            {
                var gen = new Gen();
                string json = gen.GenerateJson();
                var content = new StringContent(json, Encoding.UTF8, "text/plain"); //форматирование текста
                var response = await _httpClient.PostAsync("http://localhost/adddata", content);
                var write = new WriteToFile();
                write.WriteTextToFile(@"C:\Users\Admin\Documents\data.txt", json);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}