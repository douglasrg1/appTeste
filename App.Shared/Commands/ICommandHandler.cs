namespace App.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handler(T command);
    }
}