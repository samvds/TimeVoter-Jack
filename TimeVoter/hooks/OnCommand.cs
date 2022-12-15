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
            if (cmd.ToLower() == "day")
            {
                Commands.day.Run(player, cmd, args);
            }

            if (cmd.ToLower() == "night")
            {
                Commands.night.Run(player, cmd, args);
            }

            if (cmd.ToLower() == "settime")
            {
                Commands.settime.Run(player, cmd, args);
            }

            if (cmd.ToLower() == "time")
            {
                Commands.time.Run(player, cmd, args);

            }

            //// NEED TO FIX BELOW... COMMANDS DO NOT RUN \\\\
            /*
            //Get the Command
            Type CommandClass = Type.GetType($"Timevoter.Commands.{cmd.ToLower()}");

            //Check if the Command Exists
            if (CommandClass == null) return;

            //Setup the Parameters
            object[] parametersArray = new object[] { player, cmd, args };

            //Run the Command
            CommandClass.GetMethod("Run").Invoke(null, parametersArray);
            */
        }
    }
}
