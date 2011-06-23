using System.Collections.Generic;

namespace CommandsPreLoading.Commands
{
    public class LoadAccountsCommand : AbstractLoadCommand
    {
        private Dictionary<string, List<AccountInformation>> _accountsByModule;

        public LoadAccountsCommand(SessionInformation userSession)
            : base(userSession)
        {
        }

        public override void Execute()
        {
            //Load with provider
            _accountsByModule = new Dictionary<string, List<AccountInformation>>();

            //save into DB
        }

        public Dictionary<string, List<AccountInformation>> GetLoadedAccounts()
        {
            return _accountsByModule;
        }
    }
}
