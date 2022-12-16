//Internal References
using System;
using System.Reflection;

//External References
using Fougerite;

//Setup the Namespace
namespace TimeVoter.EventList
{

    //Setup the On Command Class
    public static class OnCommand
    {

        //Setup the Constructor
        public static void Run(Player player, string cmd, string[] args)
        {

            //Setup the Parameters
            object[] parametersArray = new object[] { player, cmd, args };

            // Get the Command Class from the String
            Type CommandClass = Type.GetType($"TimeVoter.Commands.{cmd.ToLower()}");

            //Check if the Command Exists
            if (CommandClass == null) return;

            // Retrieve the Runner Method for the Command
            MethodInfo RunnerMethod = CommandClass.GetMethod("Run");

            //Check if a Valid Runner Method Exists for the Command
            if (RunnerMethod == null) return;

            // Invoke the method on the instance we created above
            RunnerMethod.Invoke(null, parametersArray);
        }
    }
}
