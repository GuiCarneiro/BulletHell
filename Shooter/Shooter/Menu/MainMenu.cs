using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooter.Components;
using Shooter.Engines.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Menu
{
    //Main Menu
    class MainMenu
    {
        public Texture2D background;

        public int itemSelected; // What button is selected

        public List<GameButton> buttons = new List<GameButton>();

        public SpriteFont font;

        public GamePanel panel; // Buttons Panel
        public GameButton begin; // Start Button
        public GameButton help; // Help Button

        public Input input; // Keyboard and Gamepad Input
        

        public MainMenu()
        {
            this.itemSelected = -1; // No button selected

            begin = new GameButton(new Vector2((float)(Globals.WindowWidth * 0.5 - 75), (float)(Globals.WindowHeight * 0.6)), new Vector2(150, 50), "Start", 3);
            help = new GameButton(new Vector2((float)(Globals.WindowWidth * 0.5 - 75), (float)(Globals.WindowHeight * 0.6) + 55), new Vector2(150, 50), "Help", 1);

            buttons.Add(begin);
            buttons.Add(help);

            panel = new GamePanel(new Vector2((float)(Globals.WindowWidth * 0.5 - 100), (float)(Globals.WindowHeight * 0.6) - 25), new Vector2(200, 300));

            input = new Input();
        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("kenvector");
            background = content.Load<Texture2D>("Background/Background");
            panel.LoadContent(content);
            foreach (GameButton gb in buttons)
            {
                gb.LoadContent(content);
            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {            
            spriteBatch.Draw(background, new Rectangle(0, 0, Globals.WindowWidth, Globals.WindowHeight), Color.White);
            panel.Draw(spriteBatch);
            foreach (GameButton gb in buttons)
            {
                gb.Draw(spriteBatch);
            }
        }
        
        public void Update(GameTime gameTime, ref int currentGameState)
        {
            input.Update();
            GameButton button;

            //Menu Controls
            if (input.Up_Clicked())
            {
                if (itemSelected > 0)
                {
                    foreach (GameButton b in buttons)
                    {
                        b.UnSelect();
                    }

                    itemSelected--;

                    button = buttons.ElementAt(this.itemSelected);
                    button.Select();
                }

            }

            if (input.Down_Clicked())
            {
                if (itemSelected < buttons.Count() - 1)
                {
                    foreach (GameButton b in buttons)
                    {
                        b.UnSelect();
                    }

                    itemSelected++;

                    button = buttons.ElementAt(this.itemSelected);
                    button.Select();
                }
            }


            if (input.OK_Clicked())
            {
                if (itemSelected < buttons.Count() && itemSelected >= 0)
                {

                    button = buttons.ElementAt(this.itemSelected);
                    currentGameState = button.gameState;
                }
            }              
        }
    }
}
