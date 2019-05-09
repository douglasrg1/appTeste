using App.Shared.Commands;

namespace App.Domain.Commands.UserCommands
{
    public class AuthenticateUserCommand : ICommand
    {
        public AuthenticateUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}