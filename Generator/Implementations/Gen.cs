using System;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Monitoring.Models;
using Generator.Interfaces;
using System.Xml.Linq;

public class Gen : IDataGenerator
{
    public string GenerateJson()
    {
        Random random = new Random();

        var data = new Dictionary<Area, List<Parameter>>();
        float pressure, wet, temperatureArea, temperatureEquip, cO2Level;
        Area area = new Area() { Name = "StrongMachine" };
        pressure = (float)random.NextDouble() * 100;
        wet = (float)random.NextDouble() * 100;
        temperatureArea = (float)random.NextDouble() * 100;
        temperatureEquip = (float)random.NextDouble() * 100;
        cO2Level = (float)random.NextDouble() * 100;
        var parameters = new List<Parameter>()
        {
                new Parameter { type = new Monitoring.Models.Type(){name = "Pressure" }, num = pressure, date =  DateTime.UtcNow},
                new Parameter { type = new Monitoring.Models.Type(){name = "Wet" }, num = wet, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "Pressure" }, num = temperatureArea, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "Pressure" }, num = temperatureEquip, date =  DateTime.UtcNow },
                new Parameter { type = new Monitoring.Models.Type(){name = "Pressure" }, num = cO2Level, date =  DateTime.UtcNow },
        };
        data.Add(area, parameters);
        var json = JsonConvert.SerializeObject(data);
        return (json);
    }
}
