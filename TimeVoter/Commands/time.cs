//External References
using Fougerite;

//Setup the Namespace
namespace TimeVoter.Commands
{

    //Setup the Command Class
    public static class time
    {

        //Setup the Command Runner
        public static void Run(Player player, string cmd, string[] args)
        {
            if (player.Admin)
            {
                player.MessageFrom("Legacy Lives", "---------------------- [" + Colors.green + " TimeVoter Admin " + Colors.white + "] ----------------------");
                player.MessageFrom("Legacy Lives", "Use" + Colors.blue + " /settime day or night " + Colors.white + "- to set the current time to day or night.");
            }

            else
            {
                //Send the Player Information on the Time Command
                player.MessageFrom("Legacy Lives", "---------------------- [" + Colors.green + " TimeVoter " + Colors.white + "] ----------------------");
            }
            player.MessageFrom("Legacy Lives", "Use" + Colors.blue + " /day " + Colors.white + "- to vote for day.");
            player.MessageFrom("Legacy Lives", "Use" + Colors.blue + " /night " + Colors.white + "- to vote for night.");
            player.MessageFrom("Legacy Lives", "The current time is: " + Colors.blue + TimeVoter.ActualTime + Colors.white + ", and the vote will start at " + Colors.blue + "17:00" + Colors.white + ".");
        }
    }
}
