using Flunt.Notifications;
using Flunt.Validations;

namespace App.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .IsBetween(FirstName.Length,3,30,"FirstName","O nome preenchido não é valido")
                .IsBetween(LastName.Length,3,30,"FirstName","O nome preenchido não é valido")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}