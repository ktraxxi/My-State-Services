using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_State_Services.Models
{
    public class User
    {
        public User(string firstName, string surname, string patronymic,
            string loginPhoneNumber, string password)
        {
            PhotoName = "/icons/avatar.jpg";
            FirstName = firstName;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = DateTime.Now.ToString();
            Email = "нет данных";
            LoginPhoneNumber = loginPhoneNumber;
            Password = password;
            PassportNumber = "нет данных";
            MedicalPolicyNumber = "нет данных";
            TaxIdenticalNumber = "нет данных";
            InsuranceNumber = "нет данных";
            City = "нет данных";
            Street = "нет данных";
            BuildingNumber = "нет данных";
            AppartmentNumber = "нет данных";
        }
        
        public static bool isAuthorized;
        public static bool serviceRegSuccess;
        public static List<Services> AppointmentsList = new List<Services>();
        [BsonId] public ObjectId _id { get; set; }
        [BsonElement("Фото профиля")] public string PhotoName { get; set; }
        [BsonElement("Имя")] public string FirstName { get; set; }
        [BsonElement("Фамилия")] public string Surname { get; set; }
        [BsonElement("Отчество")] public string Patronymic { get; set; }
        [BsonElement("Дата рождения")] public string BirthDate { get; set; }
        [BsonElement("Электронная почта")] public string Email { get; set; }
        [BsonElement("Номер телефона / Логин")] public string LoginPhoneNumber { get; set; }
        [BsonElement("Пароль")] public string Password { get; set; }
        [BsonElement("Серия и номер паспорта")] public string PassportNumber { get; set; }
        [BsonElement("Номер медицинского полиса")] public string MedicalPolicyNumber { get; set; }
        [BsonElement("ИНН")] public string TaxIdenticalNumber { get; set; }
        [BsonElement("СНИЛС")] public string InsuranceNumber { get; set; }
        [BsonElement("Город проживания")] public string City { get; set; }
        [BsonElement("Улица")] public string Street { get; set; }
        [BsonElement("Номер дома")] public string BuildingNumber { get; set; }
        [BsonElement("Номер квартиры")] [BsonIgnoreIfNull] public string AppartmentNumber { get; set; }
        
        public static void IsAuthorizedTrue()
        {
            isAuthorized = true;
        }
        public static void IsAuthorizedFalse()
        {
            isAuthorized = false;
        }         

        public static void Registration(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            collection.InsertOne(user);            
        }
        public static void AppointmentRegistration(string login, string serviceType, DateTime? appointment)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<Services>("Appointments");
            string date = appointment.ToString();
            collection.InsertOne(new Services(login, serviceType, date));
        }
        public static User Authorization(string login, string password, User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            user = collection.Find(filter => filter.Password == password && filter.LoginPhoneNumber == login).FirstOrDefault();
            return user;
        }
        public static List<User> UserList()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            return collection.Find(x => true).ToList();
        }
        public static List<Services> UserAppointmentList()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<Services>("Appointments");
            return collection.Find(x => true).ToList();            
        }
        public static void Redact(string AnketaLogin, string firstName, string surname)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            collection.UpdateOne(x => x.LoginPhoneNumber == AnketaLogin, Builders<User>.Update.Set(x => x.FirstName, firstName).Set(x => x.Surname, surname));
        }
    }
}
