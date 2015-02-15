using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    //Static class with all Globals Variables
    public static class Globals
    {
        private static int gameWidth = 1024; //Width of the game       
        private static int windowWidth = 1024; // Width of Screen
        private static int gameHeight = 768; // Height of the game
        private static int windowHeight = 768; // Height of Screen

        public static int GameWidth
        {
            get { return Globals.gameWidth; }
        }

        public static int WindowWidth
        {
            get { return Globals.windowWidth; }
        }

        public static int GameHeight
        {
            get { return Globals.gameHeight; }
        }

        public static int WindowHeight
        {
            get { return Globals.windowHeight; }
        }
    }
}
