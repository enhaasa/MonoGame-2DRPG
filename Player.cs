using ArrPeeGee.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using  ArrPeeGee.Entities;

namespace ArrPeeGee
{
    internal static class Player
    {
        public static Character Character { get; set; }

        public static void HandleInput(KeyboardState keyState, GameTime gameTime, Map map)
        {
            if (Character == null)
            {
                return;
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                Character.Walk(Character.Direction.Up, gameTime, map);
            } else if (keyState.IsKeyDown(Keys.Down))
            {
                Character.Walk(Character.Direction.Down, gameTime, map);
            } else if (keyState.IsKeyDown(Keys.Left))
            {
                Character.Walk(Character.Direction.Left, gameTime, map);
            } else if (keyState.IsKeyDown(Keys.Right))
            {
                Character.Walk(Character.Direction.Right, gameTime, map);
            } 

            if (
                   !keyState.IsKeyDown(Keys.Up)
                && !keyState.IsKeyDown(Keys.Down)
                && !keyState.IsKeyDown(Keys.Left)
                && !keyState.IsKeyDown(Keys.Right)
            )
            {
                switch(Character.animator.State)
                {
                    case AnimationState.WalkingUp:
                        Character.Idle(Character.Direction.Up);
                        break;
                    case AnimationState.WalkingDown:
                        Character.Idle(Character.Direction.Down);
                        break;
                    case AnimationState.WalkingLeft:
                        Character.Idle(Character.Direction.Left);
                        break;
                    case AnimationState.WalkingRight:
                        Character.Idle(Character.Direction.Right);
                        break;
                }
            }



            /*


            if (keyState.IsKeyUp(Keys.Up))
            {
                Character.Idle(Character.Direction.Up);
            }
            if (keyState.IsKeyUp(Keys.Down))
            {
                Character.Idle(Character.Direction.Down);
            }
            if (keyState.IsKeyUp(Keys.Left))
            {
                Character.Idle(Character.Direction.Left);
            }
            if (keyState.IsKeyUp(Keys.Right))
            {
                Character.Idle(Character.Direction.Right);
            }
            */

        }
    }
}
