using System;
using Newtonsoft.Json;
using Monitoring.Models;
using Generator.Interfaces;
using System.Text;

public class Gen : IDataGenerator
{


    public JsonContent GenerateJson(string areaStr)
    {
        Random random = new Random();

        var data = new Dictionary<Area, List<Parameter>>();
        float pressure, wet, temperatureArea, temperatureEquip, cO2Level;
        Area area1 = new Area() { Name = "StrongMachine" };
        Area area2 = new Area() { Name = "RegularMachine" };
        pressure = (float)random.NextDouble() * 100;
        wet = (float)random.NextDouble() * 100;
        temperatureArea = (float)random.NextDouble() * 100;
        temperatureEquip = (float)random.NextDouble() * 100;
        cO2Level = (float)random.NextDouble() * 100;
        var parameters = new List<Parameter>()
        {
                new Parameter { type = new Monitoring.Models.Type(){name = "Pressure" }, num = pressure, date =  DateTime.UtcNow},
                new Parameter { type = new Monitoring.Models.Type(){name = "Wet" }, num = wet, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "TemperatureArea" }, num = temperatureArea, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "TemperatureEquip" }, num = temperatureEquip, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "CO2Level" }, num = cO2Level, date =  DateTime.UtcNow },
        };
        data.Add(area1, parameters);

        Diarea d = new Diarea() { area = area1, parameters = parameters };

        JsonContent json = JsonContent.Create(d);

        using (var httpClient = new HttpClient())
        {

            var resp = httpClient.PostAsync(@"https://localhost:7050/adddiarea/", json);
            Console.WriteLine(resp.Result);
        }


        return json;
    }
}
