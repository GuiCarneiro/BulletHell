using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Shooter.Bosses.Bullets
{
    public abstract class BossBullet
    {
        public Texture2D texture; // Image
        public Vector2 position;
        public Vector2 speed;
        public int damage;

        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;

        // Constructor
        public BossBullet(Texture2D newTexture)
        {
            this.damage = 10;
            this.texture = newTexture;
            this.speed.Y = 8;
            this.speed.X = 8;
            this.isVisible = false;

        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        // Update 
        public void Update(GameTime gameTime) {
            //Update Position
            position.Y = position.Y + speed.Y;
            position.X = position.X + speed.X;

            //Update Bounding Box
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.Y <= 0) { isVisible = false; }

            if (position.Y >= Globals.GameHeight + texture.Height) { isVisible = false; }

            if (position.X <= 0) { isVisible = false; }

            if (position.X >= Globals.GameWidth + texture.Width) { isVisible = false; }
        }
    }
}
