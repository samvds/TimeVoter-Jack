//Internal References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

//External References
using Fougerite;
using TimeVoter.EventList;

//Setup the Namespace
namespace TimeVoter
{

    //Main Class
    public class TimeVoter : Fougerite.Module
    {

        //Setup the Required Plugin Descriptors / Information
        public override string Name { get { return "TimeVoter"; } }
        public override string Author { get { return "Salva/juli x samvds x JackNytely"; } }
        public override string Description { get { return "TimeVoter"; } }
        public override Version Version { get { return new Version("1.3"); } }

        //Setup Private Variables - 1
        public static double VoteStartTime = 17.0;
        public static double VoteEndTime = VoteStartTime + 0.5;

        //Setup Private Variables - 2
        public static float ActualTime = World.GetWorld().Time;
        public static bool ActiveVote = false;
        public static int YesVoteCount = 0;
        public static int NoVoteCount = 0;

        //Setup the Voter List
        public static List<ulong> VoterIDList;

        //On Module Load
        public override void Initialize()
        {
            //Setup a New ID List
            VoterIDList = new List<ulong>();

            //Initialize the Hooks
            Hooks.OnServerInit += OnServerInit.Run;
            Hooks.OnCommand += OnCommand.Run;
        }

        //On Module UnLoad
        public override void DeInitialize()
        {
            //De-Initialize the Hooks
            Hooks.OnServerInit -= OnServerInit.Run;
            Hooks.OnCommand -= OnCommand.Run;
        }

        //Setup the Variable Resetter
        public static void ResetVariables()
        {
            TimeVoter.VoterIDList.Clear();
            TimeVoter.YesVoteCount = 0;
            TimeVoter.NoVoteCount = 0;
        }
    }
}
