
namespace CommandsPreLoading.Commands
{
    public class LoadUserGlobalsCommand : AbstractLoadCommand
    {
        private string _moduleId;
        private AccountInformation _account;
        private UserGlobals _userGlobals;

        public LoadUserGlobalsCommand(AccountInformation account, string moduleId, SessionInformation userSession)
            : base(userSession)
        {
            _moduleId = moduleId;
            _account = account;
        }

        public override void Execute()
        {
            _userGlobals = new UserGlobals();
        }
    }
}
