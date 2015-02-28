using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Engines.Graphical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Bosses.Bullets
{
    public class BossBulletCircular
    {
        public Texture2D texture; // Image
        public Vector2 position; // Cartesian Position
        public float angle, radius; // Polar Postion
        public Vector2 bPosition;
        public float speed;
        public int damage;
        public double timeCounter;
        private int angularAcceleretion;
        Vector2 rSpeed;

        private bool expand;

        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;

        // Constructor
        public BossBulletCircular(Texture2D newTexture, float angle, float radius, bool direction = true)
        {
            this.damage = 10;
            this.texture = newTexture;
            this.speed = 4;
            this.isVisible = false;
            this.angle = angle;
            this.radius = radius;
            this.expand = false;

            if (direction)
            {
                angularAcceleretion = 1;
            }
            else
            {
                angularAcceleretion = -1;
            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        // Update 
        public void Update(GameTime gameTime, Vector2 nBossCenter, Vector2 nBossSpeed)
        {
            timeCounter = timeCounter + gameTime.ElapsedGameTime.TotalSeconds;

            //Update Position
            this.bPosition = new Vector2(nBossCenter.X - texture.Width / 2, nBossCenter.Y - texture.Height / 2);
            position = position + nBossSpeed;

            // 
            Vector2 radiusDistance = bPosition + Graphical.PolarToCartesian(angle, radius);

            double degrees = Graphical.AngleBetween(position, radiusDistance);

            if (!expand)
                rSpeed = Graphical.PolarToCartesian(degrees, speed);

            position.X = position.X + rSpeed.X;
            position.Y = position.Y + rSpeed.Y;

            //

            angle = angle + angularAcceleretion;

            if (position.Y <= 0 - texture.Height - radius) { isVisible = false; }

            if (position.Y >= Globals.GameHeight + texture.Height + radius) { isVisible = false; }

            if (position.X <= 0 - texture.Width - radius) { isVisible = false; }

            if (position.X >= Globals.GameWidth + texture.Width + radius) { isVisible = false; }
        }

        public void Expand() { this.expand = true; }
    }
}
