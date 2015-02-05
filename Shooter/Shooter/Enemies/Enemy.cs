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
        public List<EnemyBullet> bulletList;
        public int health;
        public int timeOfShoot;
        public double timeCounter;
        
        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;

        // Constructor
        public Enemy()
        {
            this.health = 20;
            this.bulletDelay = 10;
            this.bulletList = new List<EnemyBullet>();
            this.texture = null;
            this.bulletTexture = null;
            this.speed.Y = 4; 
            this.speed.X = 0;
            this.isVisible = true;            
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
            foreach (EnemyBullet b in bulletList)
                b.Draw(spriteBatch);
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

            for (int i = 0; i < bulletList.Count(); i++)
            {
                bulletList[i].Update(gameTime);
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;

                    if (bulletList.Count() == 0)
                    {
                        bulletDelay = 0;
                    }
                }
            }
        }
       

        public void Shoot()
        {

            if (bulletDelay > 0) { bulletDelay--; }

            if (bulletDelay <= 0)
            {
                EnemyBullet newBullet = new EnemyBullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - newBullet.texture.Width/2, position.Y);

                newBullet.isVisible = true;

                if (bulletList.Count() < 20)
                    bulletList.Add(newBullet);
            }

            if (bulletDelay == 0) { bulletDelay = 40; }
        }

        public bool Damaged(int damage)
        {
            this.health = this.health - damage;
            if (this.health <= 0) { return true; }
            else { return false; }
        }

    }
}
