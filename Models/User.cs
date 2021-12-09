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
            DateTime birthDate, string email, string loginPhoneNumber, string password, 
            Address fullAddress, string passportNumber, string medicalPolicyNumber, 
            string taxIdenticalNumber, string insuranceNumber)
        {
            FirstName = firstName;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Email = email;
            LoginPhoneNumber = loginPhoneNumber;
            Password = password;
            FullAddress = fullAddress;
            PassportNumber = passportNumber;
            MedicalPolicyNumber = medicalPolicyNumber;
            TaxIdenticalNumber = taxIdenticalNumber;
            InsuranceNumber = insuranceNumber;
        }
        public User(string firstName, string surname, string patronymic,
            string loginPhoneNumber, string password)
        {
            FirstName = firstName;
            Surname = surname;
            Patronymic = patronymic;
            LoginPhoneNumber = loginPhoneNumber;
            Password = password;
        }

        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("Имя")]
        public string FirstName { get; set; }
        [BsonElement("Фамилия")]
        public string Surname { get; set; }
        [BsonElement("Отчество")]
        public string Patronymic { get; set; }
        [BsonElement("Дата рождения")]
        public DateTime BirthDate { get; set; }
        [BsonElement("Электронная почта")]
        public string Email { get; set; }
        [BsonElement("Номер телефона / Логин")]
        public string LoginPhoneNumber { get; set; }
        [BsonElement("Пароль")]
        public string Password { get; set; }
        [BsonElement("Полный адрес")]
        public Address FullAddress { get; set; }

        [BsonElement("Серия и номер паспорта")]
        public string PassportNumber { get; set; }
        [BsonElement("Номер медицинского полиса")]
        public string MedicalPolicyNumber { get; set; }
        [BsonElement("ИНН")]
        public string TaxIdenticalNumber { get; set; }
        [BsonElement("СНИЛС")]
        public string InsuranceNumber { get; set; }
        //private bool IsRegistered { get; set; }
        //private bool IsAuthorized { get; set; }


        public static void Registration(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            collection.InsertOne(user);
        }
        public User Authorization(string login, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            return collection.Find(filter => Password == password && LoginPhoneNumber == login).FirstOrDefault();
        }

        public static List<User> UserList()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("State_Services_Users");
            var collection = db.GetCollection<User>("Users");
            return collection.Find(x => true).ToList();
        }
    }
}
