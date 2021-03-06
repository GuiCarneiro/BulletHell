﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Engines.Input;
using Shooter.Factories;

namespace Shooter
{
    // Player - Ship Class
    public class Player
    {
        public Texture2D texture, bulletTexture, shieldTexture, shieldSymbol; // Ship and Bullet images
        public Texture2D healthTexture, healthLeft, healthRight; // Life images, center and its borders
        private SpriteFont font;
        public Vector2 position;
        public float speed, bulletDelay; // Bullet delay between each bullet fired
        public int width = 50, height = 50;
        public PlayerBulletFactory bulletsFactory = new PlayerBulletFactory();
        public int health;
        public Input input; // Kayboard or Gamepad Input
        public int shield;
        public int points;

        Rectangle healthRectangle; // Area of Health Bar

        //Colision Variables
        public Rectangle boundingBox;

        // Constructor
        public Player()
        {
            this.health = 150;
            this.bulletDelay = 8;
            this.texture = null;
            this.position = new Vector2(300, 300);
            this.speed = 5;
            this.shield = 0;
            input = new Input();

        }
        // Load Content
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("kenvector_11px");
            texture = content.Load<Texture2D>("Player/playerShip");
            bulletTexture = content.Load<Texture2D>("Player/laserBlue");
            shieldTexture = content.Load<Texture2D>("Player/shield1");
            shieldSymbol = content.Load<Texture2D>("Player/shield_gold");
            healthTexture = content.Load<Texture2D>("HUD/blueHorizontal");
            healthLeft = content.Load<Texture2D>("HUD/blue_left");
            healthRight = content.Load<Texture2D>("HUD/blue_right");
            bulletsFactory.LoadContent(content);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), Color.White);

            if (shield > 0)
            {
                spriteBatch.Draw(shieldTexture, new Rectangle((int)position.X + width/2 - shieldTexture.Width / 2, (int)position.Y + height/2 - shieldTexture.Height/2, shieldTexture.Width, shieldTexture.Height), Color.White);
                spriteBatch.Draw(shieldSymbol, new Rectangle((int)41, (int)32, 25, 25), Color.White);
                spriteBatch.DrawString(font, shield.ToString(), new Vector2(55 - font.MeasureString(shield.ToString()).X/2,35), Color.Black);
            }

            //If Life > 0 than draw life bar
            if (health > 0)
            {
                spriteBatch.Draw(healthLeft, new Rectangle(healthRectangle.X - healthLeft.Width, healthRectangle.Y, healthLeft.Width, healthRectangle.Height), Color.White);
                spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
                spriteBatch.Draw(healthRight, new Rectangle(healthRectangle.X + health, healthRectangle.Y, healthRight.Width, healthRectangle.Height), Color.White);            
            }


            bulletsFactory.Draw(spriteBatch);
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

            bulletsFactory.Update(gameTime, this);                
        }

        public void Shoot()
        {
            bulletsFactory.Shoot(this);
        }

        public bool Damaged(int damage)
        {
            if (shield > 0)
                shield = shield - 1;
            else
                this.health = this.health - damage;

            if (this.health <= 0)
                return true;
            else
                return false;
        }

        public void addPoints(int points)
        {
            this.points = this.points + points;
        }
            
    }
}
