using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Components
{
    class GameButton
    {
        public Texture2D texture;
        public Vector2 position, size;
        public bool isSelected;
        public SpriteFont font;
        public String text;
        private SoundEffect selected;
        public int gameState;

        public GameButton(Vector2 position, Vector2 size, String text, int gameState)
        {
            this.position = position;
            this.size = size;
            this.isSelected = false;
            this.text = text;
            this.gameState = gameState;
        }

        // Load Content
        public void LoadContent(ContentManager content)
        {

            font = content.Load<SpriteFont>("kenvector");
            texture = content.Load<Texture2D>("button");
            selected = content.Load<SoundEffect>("Sound/switch");
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);

            if (this.isSelected)
            {

                spriteBatch.DrawString(font, text, new Vector2(position.X + (size.X - font.MeasureString(text).X)/2, position.Y + size.Y / 4), new Color(48,94,105));
            }
            else
            {
                spriteBatch.DrawString(font, text, new Vector2(position.X + (size.X - font.MeasureString(text).X)/2, position.Y + size.Y / 4), Color.White);
            }


        }
        
        public void Select()
        {
            this.isSelected = true;
            selected.Play();
        }

        public void UnSelect()
        {
            this.isSelected = false;
        }
    }
}
