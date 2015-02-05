using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Engines.Input;

namespace Shooter
{
    // Player - Ship Class
    public class Player
    {
        public Texture2D texture, bulletTexture; // Ship and Bullet images
        public Texture2D healthTexture, healthLeft, healthRight; // Life images, center and its borders
        public Vector2 position;
        public float speed, bulletDelay; // Bullet delay between each bullet fired
        public int width = 50, height = 50;
        public List<Bullet> bulletList; // List of player bullets on screen
        public int health;
        public Input input; // Kayboard or Gamepad Input

        Rectangle healthRectangle; // Area of Health Bar

        //Colision Variables
        public Rectangle boundingBox;

        // Constructor
        public Player()
        {
            this.health = 150;
            this.bulletDelay = 8;
            this.bulletList = new List<Bullet>();
            this.texture = null;
            this.position = new Vector2(300, 300);
            this.speed = 5;
            input = new Input();

        }
        // Load Content
        public void LoadContent(ContentManager content){
            texture = content.Load<Texture2D>("Player/playerShip");
            bulletTexture = content.Load<Texture2D>("Player/laserBlue");
            healthTexture = content.Load<Texture2D>("HUD/blueHorizontal");
            healthLeft = content.Load<Texture2D>("HUD/blue_left");
            healthRight = content.Load<Texture2D>("HUD/blue_right");
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), Color.White);

            //If Life > 0 than draw life bar
            if (health > 0)
            {
                spriteBatch.Draw(healthLeft, new Rectangle(healthRectangle.X - healthLeft.Width, healthRectangle.Y, healthLeft.Width, healthRectangle.Height), Color.White);
                spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
                spriteBatch.Draw(healthRight, new Rectangle(healthRectangle.X + health, healthRectangle.Y, healthRight.Width, healthRectangle.Height), Color.White);            
            }

            foreach (Bullet b in bulletList)
                b.Draw(spriteBatch);
        }

        // Update 
        public void Update(GameTime gameTime) {
            //Get Update in Keyboard and Gamepad
            input.Update();

            healthRectangle = new Rectangle(105, 35, health, 10);

            //Ship Controls
            if (input.Up_Down())
                position.Y = position.Y - speed;

            if (input.Down_Down())
                position.Y = position.Y + speed;

            if (input.Left_Down())
                position.X = position.X - speed;

            if (input.Right_Down())
                position.X = position.X + speed;

            if (input.OK_Down())
                Shoot();
            
            // Border Limits
            if (position.X <= 0) { position.X = 0;}

            if (position.Y <= 0) { position.Y = 0;}

            if (position.X >= Globals.GameWidth - width) { position.X = Globals.GameWidth - width;}

            if (position.Y >= Globals.GameHeight - height) { position.Y = Globals.GameHeight - height; }

            //Bounding Box
            boundingBox = new Rectangle((int)position.X, (int)position.Y, width, height);

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
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + width / 2 - newBullet.texture.Width/2, position.Y - height / 2);

                newBullet.isVisible = true;

                bulletList.Add(newBullet);
            }

            if (bulletDelay == 0) { bulletDelay = 8; }
        }

        public bool Damaged(int damage)
        {
            this.health = this.health - damage;
            if (this.health <= 0) { return true; }
            else { return false; }
        }
    }
}
