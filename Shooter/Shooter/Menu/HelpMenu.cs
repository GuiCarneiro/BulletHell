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
    //Help Menu
    class HelpMenu
    {
        public Texture2D background;

        public Texture2D xboxhelp;
        public Texture2D keyboardhelp;

        public int itemSelected; // What button is selected

        public List<GameButton> buttons = new List<GameButton>();

        public SpriteFont font;

        public GamePanel panel, xboxPanel, keyboardPanel; // Button Panel and Help Panel

        public Input input = new Input(); // Keyboard and Gamepad Input

        public HelpMenu()
        {
            // No button selected
            this.itemSelected = -1;

            // Back Button
            buttons.Add(new GameButton(new Vector2((float)(Globals.WindowWidth * 0.5 - 75), (float)(Globals.WindowHeight * 0.85 + 20)), new Vector2(150, 50), "Back", 0));
            
            //Buttons Panel
            panel = new GamePanel(new Vector2((float)(Globals.WindowWidth * 0.5 - 100), (float)(Globals.WindowHeight * 0.85)), new Vector2(200, 90));
            
            //Help Panel
            xboxPanel = new GamePanel(new Vector2((float)(Globals.WindowWidth * 0.5 - 300), (float)(Globals.WindowHeight * 0.01)), new Vector2(600, 300));
            
            //Help Panel
            keyboardPanel = new GamePanel(new Vector2((float)(Globals.WindowWidth / 2 - 450), (float)(Globals.WindowHeight * 0.01 + 315)), new Vector2(900, 300));
        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("kenvector");

            background = content.Load<Texture2D>("Background/Background");

            xboxhelp = content.Load<Texture2D>("HelpMenu/Xbox");
            keyboardhelp = content.Load<Texture2D>("HelpMenu/Keyboard");

            panel.LoadContent(content);
            xboxPanel.LoadContent(content);
            keyboardPanel.LoadContent(content);
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
            keyboardPanel.Draw(spriteBatch);
            xboxPanel.Draw(spriteBatch);
            spriteBatch.Draw(xboxhelp, new Rectangle((int)(xboxPanel.position.X + xboxPanel.size.X / 2 - xboxhelp.Width / 8), (int)xboxPanel.position.Y, (int)xboxhelp.Width / 4, (int)xboxhelp.Height / 4), Color.White);
            spriteBatch.Draw(keyboardhelp, new Rectangle((int)(keyboardPanel.position.X + keyboardPanel.size.X / 2 - keyboardhelp.Width / 4.8), (int)keyboardPanel.position.Y + 10, (int)(keyboardhelp.Width / 2.4), (int)(keyboardhelp.Height / 2.4)), Color.White);
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

            //Changes actual state to corresponding in Button
            if (input.OK_Clicked())
            {
                if (itemSelected < buttons.Count() && itemSelected >= 0)
                {
                    button = buttons.ElementAt(this.itemSelected);
                    currentGameState = button.gameState;
                }
            }

            //Return to Main Menu
            if (input.Back_Clicked())
            {
                currentGameState = 0;
            }
        }
    }
}
