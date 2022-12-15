//Internal References
using System;

//External References
using Fougerite;

//Setup the Namespace
namespace TimeVoter.hooks
{

    //Setup the On Command Class
    public static class OnCommand
    {

        //Setup the Constructor
        public static void Run(Player player, string cmd, string[] args)
        {

            //Get the Command
            Type CommandClass = Type.GetType($"Timevoter.Commands.{cmd.ToLower()}");

            //Check if the Command Exists
            if (CommandClass == null) return;

            //Setup the Parameters
            object[] parametersArray = new object[] { player, cmd, args };

            //Run the Command
            CommandClass.GetMethod("Run").Invoke(null, parametersArray);
        }
    }
}
