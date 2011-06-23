namespace CommandsPreLoading.Commands
{
    public class LoadUserProfileCommand : AbstractLoadCommand
    {
        private UserProfile _userProfile;

        public LoadUserProfileCommand(SessionInformation userSession)
            : base(userSession)
        {
        }

        public override void Execute()
        {
            //Start loading => write to synch db? => profile + basedata always loaded synchroneously

            _userProfile = new UserProfile();
            //end loading => save to DB
        }

        public UserProfile GetLoadedProfile()
        {
            return _userProfile;
        }
    }
}
