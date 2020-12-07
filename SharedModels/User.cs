using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using SharedModels.FormInputs;


namespace SharedModels
{
    public class User : BaseModel
    {
        public User()
        {
            
        }

        public User(RegisterInput input)
        {
            Password = input.Password;
            PhoneNumber = input.PhoneNumber;
            FirstName = input.FirstName;
            LastName = input.Lastname;
            Email = input.Email;
            Tc = input.Tc;
        }
        /// <summary>
        /// Kullanıcı adı.
        /// </summary>
        [BsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        /// Kullanıcı soyadı.
        /// </summary>
        [BsonRequired]
        public string LastName { get; set; }

        /// <summary>
        /// Kullanıcı email adresi.
        /// </summary>
        [BsonRequired]
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcı şifresi.
        /// </summary>
        [BsonRequired]
        public string Password { get; set; }

        /// <summary>
        /// Kullanıcı TC Kimlik Numarası.
        /// </summary>
        [BsonRequired]
        public string Tc { get; set; }

        /// <summary>
        /// Kullanıcı telefon numarası.
        /// </summary>
        [BsonRequired]
        public string PhoneNumber { get; set; }

        [BsonRequired]
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Kullanıcının üyelik oluşturma tarihi.
        /// </summary>
        [BsonRequired]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Kullanıcının sipariş geçmişi.
        /// </summary>
        public List<Order> Orders { get; set; }

    }
}
