using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Components
{
    public class GamePanel
    {

        public Texture2D textureC, textureLU, textureLD, textureRD, textureRU;
        public Texture2D textureL, textureD, textureR, textureU;
        public Vector2 position, size;

        public GamePanel(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            textureLU = content.Load<Texture2D>("Panel/LU_Panel");
            textureLD = content.Load<Texture2D>("Panel/LD_Panel");
            textureRU = content.Load<Texture2D>("Panel/RU_Panel");
            textureRD = content.Load<Texture2D>("Panel/RD_Panel");
            textureC = content.Load<Texture2D>("Panel/C_Panel");

            textureL = content.Load<Texture2D>("Panel/L_Panel");
            textureD = content.Load<Texture2D>("Panel/D_Panel");
            textureU = content.Load<Texture2D>("Panel/U_Panel");
            textureR = content.Load<Texture2D>("Panel/R_Panel");
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureC, new Rectangle((int)position.X + 25, (int)position.Y + 25, (int)size.X - 50, (int)size.Y - 50), Color.White); // Center

            spriteBatch.Draw(textureLU, new Rectangle((int)position.X, (int)position.Y, textureLU.Width, textureLU.Height), Color.White); // Left Up

            spriteBatch.Draw(textureLD, new Rectangle((int)position.X, (int)(position.Y + size.Y - textureLD.Height), (int)textureLD.Width, (int)textureLD.Height), Color.White); // Left Down

            spriteBatch.Draw(textureRU, new Rectangle((int)(position.X + size.X - textureRU.Width), (int)position.Y, (int)textureRU.Width, (int)textureRU.Height), Color.White); // Right Up

            spriteBatch.Draw(textureRD, new Rectangle((int)(position.X + size.X - textureRD.Width), (int)(position.Y + size.Y - textureRD.Height), (int)textureRD.Width, (int)textureRD.Height), Color.White); // Right Down

            for (int i = 0; i < (size.Y - 50) / 25; i++)
            {
                spriteBatch.Draw(textureL, new Rectangle((int)position.X, (int)position.Y + (25 * i) + 25, textureL.Width, textureL.Height), Color.White); // Left

                spriteBatch.Draw(textureR, new Rectangle((int)(position.X + size.X - textureR.Width), (int)position.Y + (25 * i) + 25, textureR.Width, textureR.Height), Color.White); // Right
            }

            for (int i = 0; i < (size.X - 50) / 25; i++)
            {
                spriteBatch.Draw(textureU, new Rectangle((int)position.X + (25 * i) + 25, (int)position.Y, textureU.Width, textureU.Height), Color.White); // Up

                spriteBatch.Draw(textureD, new Rectangle((int)position.X + (25 * i) + 25, (int)(position.Y + size.Y - textureD.Height), textureD.Width, textureD.Height), Color.White); // Down
            }
        }        
    }
}
