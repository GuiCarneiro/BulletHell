using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Engines;

namespace Shooter.Itens
{
    public abstract class Itens
    {
        public Texture2D texture;
        public Vector2 position, speed;

        //Colision Variables
        public Rectangle boundingBox;
        public bool isVisible;


        public void Itens()
        {
            this.speed = new Vector2(0, 2);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
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

            position.Y = position.Y + speed.Y;
            position.X = position.X + speed.X;

            if (position.Y > Globals.GameHeight + texture.Height) { isVisible = false; }
            if (position.X > Globals.GameWidth + texture.Width) { isVisible = false; }
            if (position.X < 0 - texture.Width) { isVisible = false; }

           
        }

        public void Disappear() { this.isVisible = false; }

        public void Effect() { }
    }
}
