using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Engines;

namespace Shooter.Enemies
{
    public abstract class Enemy
    {
        public Texture2D texture, bulletTexture;
        public Vector2 position, speed;
        public float bulletDelay;
        public int pattern;
        public int health;
        public int timeOfShoot;
        public double timeCounter;
        public int points = 0;
        
        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;

        // Constructor
        public Enemy()
        {
            this.health = 4;
            this.texture = null;
            this.bulletTexture = null;
            this.speed.Y = 4; 
            this.speed.X = 0;
            this.isVisible = true;            
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        // Load Content
        public virtual void LoadContent(ContentManager content)
        {
        }

        // Update 
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            speed = PatternsEnemies.patternSpeed(pattern, position, speed);
            position.Y = position.Y + speed.Y;
            position.X = position.X + speed.X;

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

        public bool Die() 
        { 
            Random rand = new Random();
            this.isVisible = false;

            if(rand.NextDouble() > 0.9)
                return true;
            else
                return false;
        }

    }
}
