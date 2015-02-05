using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Shooter.Enemies;
using Shooter.Engines.Particle;
using Shooter.Level;
using Shooter.Menu;

namespace Shooter
{
    // This is the main type for your game
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics; // Video Card
        SpriteBatch spriteBatch; // Is like the brush, it is responsible for drawing


        Player p1 = new Player();
        HUD hud = new HUD();
        Level1 level1;
        MainMenu mainMenu;
        HelpMenu helpMenu;

        // Game Actual Screen
        int currentGameState = 0;
        
        public Game1()
        {
            //Graphicals Settings
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = Globals.WindowWidth;
            graphics.PreferredBackBufferHeight = Globals.GameHeight;

            //Title
            this.Window.Title = "Shooter";

            //Content Directory
            Content.RootDirectory = "Content";


            level1 = new Level1(p1);
            mainMenu = new MainMenu();
            helpMenu = new HelpMenu();       
        }

        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);  
          
            //Load Subcontent
            mainMenu.LoadContent(Content);
            helpMenu.LoadContent(Content);    
            level1.LoadContent(Content);
            
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            // Allows the game to exit
            if (keyState.IsKeyDown(Keys.Escape))
                this.Exit();

            //Depending of your game state it updates differently
            switch (currentGameState)
            {
                case (0):
                    mainMenu.Update(gameTime, ref currentGameState);
                    break;
                case (1):
                    helpMenu.Update(gameTime, ref currentGameState);
                    break;
                case (2):
                    break;
                case (3):
                    level1.Update(gameTime, Content);
                    break;
                default:
                    break;
            }


            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            //Clean Screen
            GraphicsDevice.Clear(new Color(2, 36, 79));

            //Begin Drawing
            spriteBatch.Begin();

            switch (currentGameState)
            {
                case (0):
                    mainMenu.Draw(spriteBatch);
                    base.Draw(gameTime);
                    spriteBatch.End(); // Close drawing
                    break;
                case (1):
                    helpMenu.Draw(spriteBatch);
                    base.Draw(gameTime);
                    spriteBatch.End(); // Close drawing
                    break;
                case (2):
                    break;
                case (3):
                    level1.Draw(spriteBatch);
                    base.Draw(gameTime);
                    //Don't close Drawing
                    break;
                default:
                    break;
            }
        }    
    }
}
