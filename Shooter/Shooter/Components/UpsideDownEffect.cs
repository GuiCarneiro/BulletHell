using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Components
{
    class UpsideDownEffect
    {
        Camera camera;
        public bool active = false;
        private bool increase = true;
        private bool transforming = true;
        public bool alive = true;
        private double counter;
        private Rectangle screen;
        public Texture2D texture;

        public UpsideDownEffect(ref Camera camera)
        {
            this.camera = camera;
            screen.X = Globals.GameWidth / 2;
            screen.Y = Globals.GameHeight / 2;
            screen.Width = 0;
            screen.Height = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, screen, new Color(new Vector4(0f, 0f, 0f, 0.5f)));
        }

        public void Begin()
        {
            this.active = true;
        }

        public void Update(GameTime gameTime)
        {
            counter = counter += gameTime.ElapsedGameTime.TotalSeconds;
            if(active && transforming)
            {
                Activated();
            }

            if (counter > 5 && counter < 5.5)
            {
                this.increase = true;
            }

            if (active && counter > 5)
            {
                Deactive();    
            }

        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("smokeScreen");
        }


        public void Activated()
        {
            if (increase)
            {
                Increase( 3.14f );
            }            
            else
            {
                Decrease();
            }
            
        }

        private void Increase(float angle)
        {
            screen.Width = screen.Width + 10;
            screen.X = screen.X - 5;


            screen.Height = screen.Height + 8;
            screen.Y = screen.Y - 4;

            if (screen.Width >= Globals.GameWidth && screen.Height >= Globals.GameHeight)
            {
                camera.Rotation = angle;
                increase = false;
            }
        }

        private void Decrease()
        {
            screen.Width = screen.Width - 10;
            screen.X = screen.X + 5;


            screen.Height = screen.Height - 8;
            screen.Y = screen.Y + 4;

            if (screen.Width <= 0 && screen.Height <= 0)
            {
                transforming = false;
            }
        }

        private void Deactive()
        {
            if (increase)
            {
                Increase( 0f );
            }
            else
            {
                Decrease();
                if (screen.Width <= 0 && screen.Height <= 0)
                    alive = false;
            }
        }
    }
}
