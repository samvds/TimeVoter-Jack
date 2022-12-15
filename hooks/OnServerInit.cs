//Internal References
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

//External References
using Fougerite;

//Setup the Namespace
namespace TimeVoter.hooks
{
    //Setup the Server Init Class
    public static class OnServerInit
    {

        //Setup the Runner
        public static void Run()
        {

            //Setup Variables
            Timer clock = new Timer();

            //Setup default Values
            clock.Interval = 10000;
            clock.AutoReset = true;
            clock.Elapsed += Elapsed;

            //Start the Clock
            clock.Start();
        }

        //Setup the Elapsed Time Handler
        private static void Elapsed(object x, object y)
        {

            //Update the Current World Time
            TimeVoter.ActualTime = World.GetWorld().Time;

            //Get the Server Object
            Server ServerObject = Server.GetServer();

            //Check if the Current Time has reached the threshold for the Vote to Start
            if (TimeVoter.ActualTime >= TimeVoter.VoteStartTime && TimeVoter.ActualTime <= TimeVoter.VoteEndTime && !TimeVoter.ActiveVote)
            {
                ServerObject.BroadcastNotice("Time to vote!");
                ServerObject.BroadcastFrom("Legacy Lives", "Use" + Colors.blue + " /day " + Colors.white + "- to vote for daytime.");
                ServerObject.BroadcastFrom("Legacy Lives", "Use" + Colors.blue + " /night " + Colors.white + "- to vote for nighttime.");
                TimeVoter.ActiveVote = true;
            }

            //Check if the Active Vote has reached its time limit
            if (TimeVoter.ActualTime > TimeVoter.VoteEndTime && TimeVoter.ActiveVote)
            {
                TimeVoter.ActiveVote = false;
                CheckVotes();
            }
        }

        //Setup the Vote Checker
        public static void CheckVotes()
        {
            //Get the Server Object
            Server ServerObject = Server.GetServer();

            //Setup Variables
            bool VoteSuccessful = TimeVoter.YesVoteCount > TimeVoter.NoVoteCount;
            string VoteResultString = VoteSuccessful ? "Daytime Wins!" : "Nighttime Wins!";

            //Broadcast Results
            ServerObject.BroadcastFrom("Legacy Lives", $"☢ The results are in: {Colors.blue}{TimeVoter.YesVoteCount}{Colors.white} votes for daytime and {Colors.blue}{TimeVoter.NoVoteCount}{Colors.white} votes for nighttime.");
            ServerObject.BroadcastFrom("Legacy Lives", $"☢ {Colors.green}{VoteResultString}");

            //Set the World Time
            World.GetWorld().Time = VoteSuccessful ? 7 : World.GetWorld().Time;

            //Reset the Variables
            TimeVoter.ResetVariables();
        }
    }
}
