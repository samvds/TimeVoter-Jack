//Setup the Namespace
namespace TimeVoter
{
    //Setup the Colors Class
    public static class Colors
    {
        //Define Premade Colors
        public static string red = "[color #FF0000]";
        public static string blue = "[color #00ffff]";
        public static string green = "[color #00ff00]";
        public static string yellow = "[color #ffff00]";
        public static string white = "[color #ffffff]";

        //Allow user to Create their Own Color from Hex String
        public static string GetColor(string HexCode)
        {

            //Return the Color String
            return $"[color {HexCode}]";
        }
    }
}
