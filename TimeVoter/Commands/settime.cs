//External References
using Fougerite;

//Setup the Namespace
namespace TimeVoter.Commands
{

    //Setup the Command Class
    public static class settime
    {

        //Setup the Command Runner
        public static void Run(Player player, string cmd, string[] args)
        {

            //Check if no Arguments were given
            if(args.Length < 1 && player.Admin)
            {

                //Give the Player Information on the Set Time Command
                player.MessageFrom("Legacy Lives", Colors.yellow + "☢ " + Colors.red + "Please choose the time to set: " + Colors.yellow + "'/settime day' or '/settime night'" + Colors.red + ".");

                //End the Method
                return;
            }

           //Check if the Player has chosen to set the time to Day
            if (args[0].ToLower() == "day" && player.Admin) 
            {

                //Set the Time to Day
                World.GetWorld().Time = 7;
                Server.GetServer().BroadcastFrom("Legacy Lives", "☢ " + Colors.white + "A server admin has changed the time to: " + Colors.blue + "daytime.");

                //End the Method
                return;
            };

            //Check if the Player has chosen to set the time to Night
            if (args[0].ToLower() == "night" && player.Admin) 
            {

                //Set the Time to Night
                World.GetWorld().Time = 17;
                Server.GetServer().BroadcastFrom("Legacy Lives", "☢ " + Colors.white + "A server admin has changed the time to: " + Colors.blue + "daytime.");

                //End the Method
                return;
            };
        }
    }
}
