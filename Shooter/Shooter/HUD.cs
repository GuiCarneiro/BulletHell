using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Components;

namespace Shooter
{
    //HUD - Heads on Display
    // This class works with the whole UI that our player is going to use
    public class HUD
    {
        
        public Texture2D panel; // Superior panel
        public Vector2 scorePos; // Position of point's counter
        public SpriteFont font; // Graphical font
        public int score; // Total of points
        public Warning warning;

        // Constructor
        public HUD(int score = 0)
        {
            warning = new Warning();
            this.score = score;
            this.scorePos = new Vector2(100,75);
            this.font = null;

        }
        // Load Content
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("kenvector");
            panel = content.Load<Texture2D>("HUD/main_hud");

            warning.LoadContent(content);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            // UI Panel 
            spriteBatch.Draw(panel, new Rectangle(10, 0, panel.Width / 4, panel.Height / 4), Color.White);
            
            //Score String
            spriteBatch.DrawString(font, ""+score, scorePos, Color.White);

            warning.Draw(spriteBatch);
        }

        // Update 
        public void Update(GameTime gameTime){
            warning.Update(gameTime);

        }
    }
}
