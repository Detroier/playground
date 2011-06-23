namespace CommandsPreLoading.Commands
{
    public class LoadBaseDataCommand : AbstractLoadCommand
    {
        private BaseData _baseData;

        public LoadBaseDataCommand(SessionInformation userSession)
            : base(userSession)
        {
        }

        public override void Execute()
        {
            _baseData = new BaseData();
            //save to DB?
        }

        public BaseData GetBaseData()
        {
            return _baseData;
        }
    }
}
