using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Shooter
{
    // Starfild Background
    // This class controls the background of our level
    // And give a filling of animation
    public class StarField
    {
        public Texture2D texture; // Background image
        public Vector2 bgPosition1, bgPosition2; // Position for 2 images
        public float speed; // Speed of background moving


        // Constructor
        public StarField()
        {
            this.texture = null;
            this.bgPosition1 = new Vector2(0, 0);
            this.bgPosition2 = new Vector2(0, -950);
            this.speed = 5;

        }
        // Load Content
        public void LoadContent(ContentManager content){
            texture = content.Load<Texture2D>("space");
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Rectangle((int)bgPosition1.X, (int)bgPosition1.Y, Globals.GameWidth, texture.Height), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)bgPosition2.X, (int)bgPosition2.Y, Globals.GameWidth, texture.Height), Color.White);
        }

        // Update 
        // Moves each background image
        // So the player thinks that the ships is moving
        public void Update(GameTime gameTime) {
            //Update each position
            bgPosition1.Y = bgPosition1.Y + speed;
            bgPosition2.Y = bgPosition2.Y + speed;

            //Than reset if is over the limit of the screen
            if (bgPosition1.Y >= texture.Height)
            {
                bgPosition1.Y = 0;
                bgPosition2.Y = -texture.Height;
            }
        }
    }
}
