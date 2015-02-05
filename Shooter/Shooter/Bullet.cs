﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Shooter
{
    //Base Class for Bullets
    public class Bullet
    {
        public Texture2D texture; // Image
        public Vector2 position;
        public float speed;
        public int damage;

        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;

        // Constructor
        public Bullet(Texture2D newTexture)
        {
            this.damage = 20;
            this.texture = newTexture;
            this.speed = 20;
            this.isVisible = false;

        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        // Update 
        public void Update(GameTime gameTime) {
            //Update Position
            position.Y = position.Y - speed;

            //Update Bounding Box
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.Y <= 0) { isVisible = false; }
        }
    }
}
