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

        public static double AngleBetween(Vector2 vector1, Vector2 vector2)
        {
            float angle = (float)Math.Atan2(vector2.Y - vector1.Y, vector2.X - vector1.X);
            return MathHelper.ToDegrees(angle);
        }

        public static double AngleBetween(Rectangle vector1, Rectangle vector2)
        {
            return AngleBetween(new Vector2(vector1.X, vector1.Y), new Vector2(vector2.X, vector2.Y));
        }

        public static double AngleBetween(Vector2 vector1, Rectangle vector2)
        {
            return AngleBetween(vector1, new Vector2(vector2.X, vector2.Y));
        }

        public static double AngleBetween(Rectangle vector1, Vector2 vector2)
        {
            return AngleBetween(new Vector2(vector1.X, vector1.Y), vector2);
        }
    }
}
