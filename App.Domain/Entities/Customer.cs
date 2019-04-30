using System;
using App.Shared.Entity;
using Flunt.Validations;

namespace App.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName, DateTime birthDate, string email,User user)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            User = user;

            AddNotifications(new Contract()
                .IsBetween(FirstName.Length,3,30,"FirstName","O nome preenchido não é valido")
                .IsBetween(LastName.Length,3,30,"FirstName","O nome preenchido não é valido")
                .IsEmail(email,"Email","O E-mail preenchido não é valido")
            );
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}