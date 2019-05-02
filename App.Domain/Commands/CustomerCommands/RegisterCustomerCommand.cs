using App.Shared.Commands;

namespace App.Domain.Commands.CustomerCommands
{
    public class RegisterCustomerCommand :ICommand
    {
        public RegisterCustomerCommand(string firstName, string lastName, string email, string document, string username, string password, string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
    }
}