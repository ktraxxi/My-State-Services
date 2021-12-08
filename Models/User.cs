using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateServices
{
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("Имя")]
        private string FirstName { get; set; }
        [BsonElement("Фамилия")]
        private string Surname { get; set; }
        [BsonElement("Отчество")]
        private string Patronymic { get; set; }
        [BsonElement("Дата рождения")]
        public DateTime BirthDate { get; set; }
        [BsonElement("Электронная почта")]
        private string Email { get; set; }
        [BsonElement("Номер телефона / Логин")]
        private string LoginPhoneNamber { get; set; }
        [BsonElement("Пароль")]
        private string Password { get; set; }
        [BsonElement("Полный адрес")]
        public Address FullAddress { get; set; }

        [BsonElement("Серия и номер паспорта")]
        private string PassportNumber { get; set; }
        [BsonElement("Номер медицинского полиса")]
        private string MedicalPolicyNumber { get; set; }
        [BsonElement("ИНН")]
        private string TaxIdenticalNumber { get; set; }
        [BsonElement("СНИЛС")]
        private string InsuranceNumber { get; set; }
        private bool IsRegistered { get; set; }
        private bool IsAuthorized { get; set; }


        public void Registration()
        {

        }

        public void Authorization()
        {

        }
    }
}
