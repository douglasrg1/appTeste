using App.Shared.Commands;

namespace App.Domain.Commands.UserCommands
{
    public class AuthenticateUserCommand : ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}