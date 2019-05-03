using System;
using App.Domain.ValueObjects;
using App.Shared.Entity;
using Flunt.Validations;

namespace App.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {
            
        }
        public Customer(Name name,Document document, DateTime birthDate, Email email,User user)
        {
            Name = name;
            Document = document;
            BirthDate = birthDate;
            Email = email;
            User = user;

            AddNotifications(Name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(user.Notifications);
        }
        
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public User User { get; private set; }

        

    }
}