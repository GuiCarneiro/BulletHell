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
    public class Warning
    {
        public Texture2D texture;
        public Vector2 position;
        public String isActivated;
        private float alpha = 0;
        private bool alphaChange = true;
        private double timeActivated = 0;

        private SoundEffect warning;
        private SoundEffectInstance instance;

        public Warning()
        {
            this.position = new Vector2(Globals.GameWidth, Globals.GameHeight/2);
            this.isActivated = "right";
        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("HUD/warning");
            warning = content.Load<SoundEffect>("Sound/BossAppear");
            instance = warning.CreateInstance();
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)Globals.WindowHeight / 2 - texture.Height / 2, texture.Width, texture.Height), new Color(new Vector4(1f, 1f, 1f, alpha)));
        }

        public void Update(GameTime gameTime)
        {
            if (alphaChange)
            {
                alpha = alpha + (float)0.1;
                if (alpha >= 1) { alphaChange = false; }
            }
            else
            {
                alpha = alpha - (float)0.1;
                if (alpha <= 0) { alphaChange = true; }
            }

            if (timeActivated >= 5) 
            {
                isActivated = "left";
            }

            if(isActivated == "center")
            {
                timeActivated += gameTime.ElapsedGameTime.TotalSeconds;
                if(position.X > Globals.WindowWidth / 2 - texture.Width / 2)
                {
                    position.X = position.X - 5;
                }
            }

            if (isActivated == "left" && position.X > - texture.Width)
            {
                position.X = position.X - 5;
            }
        }
        
        public void Activate()
        {
            this.isActivated = "center";

            if (instance.State != SoundState.Playing)
            {
                instance.Play();
            }
        }
    }
}
