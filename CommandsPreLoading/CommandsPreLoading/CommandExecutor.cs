using System.Threading;
using CommandsPreLoading.Commands;

namespace CommandsPreLoading
{
    public static class CommandExecutor
    {

        public static void ExecuteNow(ICommand command)
        {
            command.Execute();
        }

        public static void ExecuteLater(ICommand command)
        {            
            Thread worker = new Thread(() =>
            {
                command.Execute();
            });
            worker.Start();
        }

    }
}
