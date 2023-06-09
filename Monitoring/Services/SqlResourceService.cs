﻿using Monitoring.Interfaces;
using Monitoring.Models;
using Monitoring.Interfaces;
using Monitoring.DataAccessLayer;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection.Metadata;

namespace Monitoring.Services
{
    public class SqlResourceService : IResourceService
    {
        private DataContext db = new DataContext();

        public void AddArea(Area Area)
        {
            db.Areas.Add(Area);
            db.SaveChangesAsync();
        }

        public void AddDiarea(Diarea diarea)
        {
            if (db.Areas.AsEnumerable().Where(a => a.name == diarea.area.name).ToList().Count == 1)
                foreach (var p in diarea.parameters)
                {
                    p.area = diarea.area;
                    db.Parameters.Add(p);
                    db.SaveChangesAsync();
                }

        }

        public void AddParameter(Models.Parameter parameter)
        {   string token = "6166785103:AAENUDBKarPw8YQGo55M3B1cSYUdWtHOOOE";
            long chatId = -1001900397982;
            TelegramBotClient botClient = new TelegramBotClient(token);
            db.Parameters.Add(parameter);
            AreaParam ap = db.AreaParams.Where(x => x.area.name == parameter.area.name).Where(x => x.type.name == parameter.type.name).First();
            if (parameter.num > ap.max || parameter.num < ap.min)
            {
                var message = $"ALARM!!!!\n{parameter.type.name} = {parameter.num}";
                botClient.SendTextMessageAsync(chatId, message);
            }
            db.SaveChanges();
        }

        public void ClearParameters()
        {
            db.Parameters.RemoveRange(db.Parameters.AsEnumerable());
        }
        public void AddParameterToArea(AreaParam ap)
        {
            Models.Type type;
            if (!db.Types.AsEnumerable().Select(x => x.name).Contains(ap.type.name))
            {
                type = new Models.Type() { name = ap.type.name };
                db.Types.Add(type);
            }
            else
            {
                type = db.Types.AsEnumerable().Where(x => x.name == ap.type.name).FirstOrDefault();
            }
            Area area = db.Areas.FirstOrDefault(a => a.name == ap.area.name);  
            ap.area = area;
            ap.type = type;
            db.AreaParams.Add(ap); 
            db.SaveChangesAsync();
        }

        public List<float> GetParamsValueFromArea(Area area, Models.Type type)
        {
            return db.Parameters.Where(x => x.area == area && x.type == type).Select(x => x.num).ToList();
        }

        public List<DateTime> GetParamsDatesFromArea(Area area, Models.Type type)
        {
            return db.Parameters.Where(x => x.area == area && x.type == type).Select(x => x.date).ToList();
        }

        public List<Models.Parameter> GetAllParameters()
        {
            return db.Parameters.ToList();
        }

        public Area GetArea(string name)    
        {
            return db.Areas.Where(x => x.name == name).FirstOrDefault();
        }

        public List<Area> GetAreas()
        {
            return db.Areas.ToList();
        }

        public List<Models.Type> GetParamsTypesByArea(Area area)
        {
            
            return db.Types.AsEnumerable().Where(x => db.AreaParams.AsEnumerable().Where(t => t.area == area).Select(r => r.type).ToList().Contains(x)).ToList();
        }

        public void AddParametersFromFile(string str)
        {
            throw new NotImplementedException();
        }

        List<Models.Parameter> IResourceService.GetAllParameters()
        {
            throw new NotImplementedException();
        }
    }
}
