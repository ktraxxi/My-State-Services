using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_State_Services.Models
{
    public class Address
    {
        public Address(string city, string street, string buildingNumber, string appartmentNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
            AppartmentNumber = appartmentNumber;
        }
        public Address(string city, string street, string buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        [BsonElement("Город проживания")]
        private string City { get; set; }
        [BsonElement("Улица")]
        private string Street { get; set; }
        [BsonElement("Номер дома")]
        private string BuildingNumber { get; set; }
        [BsonElement("Номер квартиры")]
        [BsonIgnoreIfNull]
        private string AppartmentNumber { get; set; }


    }
}
