//External References
using Fougerite;

//Setup the Namespace
namespace TimeVoter.Commands
{

    //Setup the Command Class
    public static class night
    {

        //Setup the Command Runner
        public static void Run(Player player, string cmd, string[] args)
        {

            //Check if there is no Vote Running
            if (!TimeVoter.ActiveVote)
            {

                //Send the Player a notice that there is currently no vote running
                player.MessageFrom("Legacy Lives", Colors.yellow + "☢ " + Colors.red + "There is no vote running!");

                //End the Method
                return;
            }

            //Check if the Player has Already Voted
            if (TimeVoter.VoterIDList.Contains(player.UID))
            {

                //Send the Player a notice that they have already voted
                player.MessageFrom("Legacy Lives", Colors.yellow + "☢ " + Colors.green + "You have voted succesfully!");

                //End the Method
                return;
            }

            //Send the Player a notice that they have successfully voted
            player.MessageFrom("Legacy Lives", Colors.yellow + "☢ " + Colors.green + "You have voted for nighttime!");

            //Increment the No Vote Counter
            TimeVoter.NoVoteCount += 1;

            //Add the Player to the List of Voters
            TimeVoter.VoterIDList.Add(player.UID);

            //Send the Server a notice updating the current vote count
            Server.GetServer().BroadcastFrom("Legacy Lives", "As it currently stands, there are:");
            Server.GetServer().BroadcastFrom("Legacy Lives", "☢ " + Colors.blue + TimeVoter.YesVoteCount + Colors.white + " vote(s) for daytime and " + Colors.blue + TimeVoter.NoVoteCount + Colors.white + " vote(s) for nighttime.");
            Server.GetServer().BroadcastFrom("Legacy Lives", "☢ " + Colors.blue + player.Name + Colors.white + " has voted for nighttime!");
        }
    }
}
