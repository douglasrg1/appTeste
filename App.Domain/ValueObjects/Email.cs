using Flunt.Notifications;
using Flunt.Validations;

namespace App.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .IsEmail(address,"Email","O E-mail preenchido não é valido")
            );
        }

        public string Address { get; private set; }

    }
}