using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Project_State_Services.Models
{
    public class Services
    {
        [BsonId] public ObjectId _id { get; set; }
        [BsonElement("Логин пользователя")] public string UserLogin { get; set; }
        [BsonElement("Дата и время записи")] public string ServiceDate { get; set; }
        [BsonElement("Тип услуги")] public string ServiceType { get; set; }

        public Services(string userLogin, string type, string date)
        {
            UserLogin = userLogin;
            ServiceType = type;
            ServiceDate = date;
        }
    }
}
