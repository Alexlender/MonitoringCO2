/*using Monitoring.Models;
using System.Net.Http.Json;

var parameters = new List<Parameter>()
        {
                new Parameter { type = new Monitoring.Models.Type(){name = "Pressure" }, num = 1f, date =  DateTime.UtcNow},
                new Parameter { type = new Monitoring.Models.Type(){name = "Wet" }, num = 2f, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "TemperatureArea" }, num = 3f, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "TemperatureEquip" }, num = 4f, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "CO2Level" }, num = 5f, date =  DateTime.UtcNow },
        };
Area area1 = new Area() { Name = "StrongMachine" };
Diarea d = new Diarea() { area = area1, parameters = parameters };

JsonContent json = JsonContent.Create(d);

using (var httpClient = new HttpClient())
{

    var resp = httpClient.PostAsync(@"https://localhost:7050/adddiarea", json);
    Console.WriteLine(resp.Result);
}
*/
using Monitoring.Models;
using System.Net.Http.Json;


namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parameter tom = new Parameter { num = 38f, id = 1 };
            for (int i = 1000; i > 0; i--)
            {
                using (var httpClient = new HttpClient())
                {
                    JsonContent content = JsonContent.Create(tom);
                    // отправляем запрос
                    var resp = httpClient.PostAsJsonAsync(@"https://localhost:7050/adddata", tom);
                    Console.WriteLine(resp.Result);
                }
            }
        }
    }
}