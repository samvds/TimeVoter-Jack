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
            if(args.Length < 1)
            {

                //Give the Player Information on the Set Time Command
                player.MessageFrom("Legacy Lives", Colors.yellow + "☢ " + Colors.red + "Please choose the time to set: '/SetTime Day' or '/SetTime Night'");

                //End the Method
                return;
            }

           //Check if the Player has chosen to set the time to Day
            if (args[0].ToLower() == "day") 
            {

                //Set the Time to Day
                World.GetWorld().Time = 7;

                //End the Method
                return;
            };

            //Check if the Player has chosen to set the time to Night
            if (args[0].ToLower() == "night") 
            {

                //Set the Time to Night
                World.GetWorld().Time = 17;

                //End the Method
                return;
            };
        }
    }
}
