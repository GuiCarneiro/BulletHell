using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Engines.Input
{
    public class Input
    {
        KeyboardState keyState, oldState;
        GamePadState gamePadState, oldPadState;

        public Input()
        {

        }

        public void Update()
        {
            oldPadState = gamePadState;
            oldState = keyState;

            keyState = Keyboard.GetState();
            gamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public bool Left_Down()
        {
            if (keyState.IsKeyDown(Keys.A) || gamePadState.DPad.Left == ButtonState.Pressed || gamePadState.ThumbSticks.Left.X < 0)
                return true;
            else
                return false;
        }

        public bool Right_Down()
        {
            if (keyState.IsKeyDown(Keys.D) || gamePadState.DPad.Right == ButtonState.Pressed || gamePadState.ThumbSticks.Left.X > 0)
                return true;
            else
                return false;
        }

        public bool Up_Down()
        {
            if (keyState.IsKeyDown(Keys.W) || gamePadState.DPad.Up == ButtonState.Pressed || gamePadState.ThumbSticks.Left.Y > 0)
                return true;
            else
                return false;
        }

        public bool Down_Down()
        {
            if (keyState.IsKeyDown(Keys.S) || gamePadState.DPad.Down == ButtonState.Pressed || gamePadState.ThumbSticks.Left.Y < 0)
                return true;
            else
                return false;
        }

        public bool Back_Down()
        {
            if (keyState.IsKeyDown(Keys.Back) || gamePadState.Buttons.Back == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool OK_Down()
        {
            if (keyState.IsKeyDown(Keys.Space) || keyState.IsKeyDown(Keys.Enter) || gamePadState.Buttons.A == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Cancel_Down()
        {
            if (keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift) || gamePadState.Buttons.B == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Info_Down()
        {
            if (keyState.IsKeyDown(Keys.LeftControl) || keyState.IsKeyDown(Keys.LeftControl) || gamePadState.Buttons.X == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Extra_Down()
        {
            if (keyState.IsKeyDown(Keys.LeftAlt) || keyState.IsKeyDown(Keys.RightAlt) || gamePadState.Buttons.Y == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Left_Clicked()
        {
            if (oldState.IsKeyDown(Keys.A) && keyState.IsKeyUp(Keys.A))
            {
                return true;
            }

            if (oldPadState.DPad.Left == ButtonState.Pressed && gamePadState.DPad.Left == ButtonState.Released)
            {
                return true;
            }

            if (oldPadState.ThumbSticks.Left.X < 0 && gamePadState.ThumbSticks.Left.X > 0)
            {
                return true;
            }

            return false;
        }

        public bool Right_Clicked()
        {
            if (oldState.IsKeyDown(Keys.D) && keyState.IsKeyUp(Keys.D))
            {
                return true;
            }

            if (oldPadState.DPad.Right == ButtonState.Pressed && gamePadState.DPad.Right == ButtonState.Released)
            {
                return true;
            }

            if (oldPadState.ThumbSticks.Left.X > 0 && gamePadState.ThumbSticks.Left.X < 0)
            {
                return true;
            }

            return false;
        }

        public bool Up_Clicked()
        {
            if (oldState.IsKeyDown(Keys.W) && keyState.IsKeyUp(Keys.W))
            {
                return true;
            }

            if (oldPadState.DPad.Up == ButtonState.Pressed && gamePadState.DPad.Up == ButtonState.Released)
            {
                return true;
            }

            if (oldPadState.ThumbSticks.Left.Y > 0 && gamePadState.ThumbSticks.Left.Y <= 0)
            {
                return true;
            }

            return false;
        }

        public bool Down_Clicked()
        {
            if (oldState.IsKeyDown(Keys.S) && keyState.IsKeyUp(Keys.S))
            {
                return true;
            }

            if (oldPadState.DPad.Down == ButtonState.Pressed && gamePadState.DPad.Down == ButtonState.Released)
            {
                return true;
            }

            if (oldPadState.ThumbSticks.Left.Y < 0 && gamePadState.ThumbSticks.Left.Y >= 0)
            {
                return true;
            }

            return false;
        }

        public bool Back_Clicked()
        {

            if (oldState.IsKeyDown(Keys.Back) && keyState.IsKeyUp(Keys.Back))
            {
                return true;
            }

            if (oldPadState.Buttons.Back == ButtonState.Pressed && gamePadState.Buttons.Back == ButtonState.Released)
            {
                return true;
            }

            return false;
        }

        public bool OK_Clicked()
        {
            if (oldState.IsKeyDown(Keys.Space) && keyState.IsKeyUp(Keys.Space))
            {
                return true;
            }

            if (oldState.IsKeyDown(Keys.Enter) && keyState.IsKeyUp(Keys.Enter))
            {
                return true;
            }

            if (oldPadState.Buttons.A == ButtonState.Pressed && gamePadState.Buttons.A == ButtonState.Released)
            {
                return true;
            }

            return false;
        }

        public bool Cancel_Clicked()
        {
            if (oldState.IsKeyDown(Keys.LeftShift) && keyState.IsKeyUp(Keys.LeftShift))
            {
                return true;
            }

            if (oldState.IsKeyDown(Keys.RightShift) && keyState.IsKeyUp(Keys.RightShift))
            {
                return true;
            }

            if (oldPadState.Buttons.B == ButtonState.Pressed && gamePadState.Buttons.B == ButtonState.Released)
            {
                return true;
            }

            return false;
        }

        public bool Info_Clicked()
        {
            if (oldState.IsKeyDown(Keys.LeftControl) && keyState.IsKeyUp(Keys.LeftControl))
            {
                return true;
            }

            if (oldState.IsKeyDown(Keys.RightControl) && keyState.IsKeyUp(Keys.RightControl))
            {
                return true;
            }

            if (oldPadState.Buttons.X == ButtonState.Pressed && gamePadState.Buttons.X == ButtonState.Released)
            {
                return true;
            }

            return false;
        }

        public bool Extra_Clicked()
        {
            if (oldState.IsKeyDown(Keys.LeftAlt) && keyState.IsKeyUp(Keys.LeftAlt))
            {
                return true;
            }

            if (oldState.IsKeyDown(Keys.RightAlt) && keyState.IsKeyUp(Keys.RightAlt))
            {
                return true;
            }

            if (oldPadState.Buttons.Y == ButtonState.Pressed && gamePadState.Buttons.Y == ButtonState.Released)
            {
                return true;
            }

            return false;
        }
    }
}
