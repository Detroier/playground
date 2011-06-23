namespace CommandsPreLoading.Commands
{
    public abstract class AbstractLoadCommand : ICommand
    {
        protected SessionInformation _userSession;

        public AbstractLoadCommand(SessionInformation userSession)
        {
            _userSession = userSession;
        }

        public abstract void Execute();
    }
}
