using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Bosses.Bullets;

namespace Shooter.Bosses
{
    public abstract class Boss
    {
        public Texture2D texture, bulletTexture1, bulletTexture2, bulletTexture3;

        public Texture2D healthMid, healthBottom, healthTop; // Life images, center and its borders

        public Rectangle healthRectangle;

        public int initialLife, initialHeight, healthAnimation;

        public Vector2 position, speed;
        
        public List<BossBulletStraight> bulletList;
        public int health;
        public int timeOfShoot;
        public double timeCounter;
        public int score;

        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;

         // Constructor
        public Boss()
        {
            this.health = 1000;
            this.bulletList = new List<BossBulletStraight>();
            this.texture = null;

            //All three states of bullets
            this.bulletTexture1 = null;
            this.bulletTexture2 = null;
            this.bulletTexture3 = null;

            this.isVisible = true;            
        }

        // Draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
           foreach (BossBulletStraight b in bulletList)
               b.Draw(spriteBatch);
        }

        // Load Content
        public virtual void LoadContent(ContentManager content)
        {
        }


        // Update 
        public virtual void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            
            position.Y = position.Y + (float) 0.1;

            if (position.Y > Globals.GameHeight + texture.Height) { isVisible = false; }

            if (position.X > Globals.GameWidth + texture.Width) { isVisible = false; }

            if (position.X < 0 - texture.Width) { isVisible = false; }
        }

        public bool Damaged(int damage)
        {
            this.health = this.health - damage;
            if (this.health <= 0) { return true; }
            else { return false; }
        }

    }
}
