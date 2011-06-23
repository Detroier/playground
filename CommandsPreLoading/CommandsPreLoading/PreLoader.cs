using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandsPreLoading.Commands;

namespace CommandsPreLoading
{
    //static?
    public static class PreLoader
    {
        /// <summary>
        /// 
        /// </summary>
        public static void EnsureRequiredDataLoaded()
        {
            //check for sesion
            SessionInformation userSession = FetchCurrentUserSession();

            //now this sucks!
            //3x check for DB => not really wanted.
            // + check to DB for every call => not nice!
            // is there a way to get complete info?

            //=> so: something like 

            UserLoadingState state = GetUserLoadingState(userSession);
            //and check from state => maybe better?

            //need different way => have it in session?
            if (IsUserProfileForSessionLoaded(userSession) == false)
            {
                ICommand userProfileLoadCommand = new LoadUserProfileCommand(userSession);
                CommandExecutor.ExecuteNow(userProfileLoadCommand);
            }

            if (IsBaseDataForSessionLoaded(userSession) == false)
            {
                ICommand baseDataLoadCommand = new LoadBaseDataCommand(userSession);
                CommandExecutor.ExecuteNow(baseDataLoadCommand);
            }

            if (AreAccountsLoaded(userSession) == false)
            {

            }

        }

        private static UserLoadingState GetUserLoadingState(SessionInformation userSession)
        {
            return new UserLoadingState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSession"></param>
        /// <returns></returns>
        private static bool AreAccountsLoaded(SessionInformation userSession)
        {
            //hmm!
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSession"></param>
        /// <returns></returns>
        private static bool IsBaseDataForSessionLoaded(SessionInformation userSession)
        {
            return false;
        }

        /// <summary>
        /// CHeck data in database.
        /// </summary>
        /// <param name="userSession"></param>
        /// <returns></returns>
        private static bool IsUserProfileForSessionLoaded(SessionInformation userSession)
        {
            return false;
        }

        /// <summary>
        /// To be done by specific class
        /// </summary>
        /// <returns></returns>
        private static SessionInformation FetchCurrentUserSession()
        {
            return new SessionInformation();
        }
    }
}
