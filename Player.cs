using ArrPeeGee.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ArrPeeGee
{
    public enum CollisionDirections
    {
        Up,
        Down, 
        Left, 
        Right
    }
    public enum MotionStates
    {
        WalkingUp,
        WalkingDown,
        WalkingLeft,
        WalkingRight,
        StandingUp,
        StandingDown,
        StandingLeft,
        StandingRight,
    }
    internal static class Player
    {
        public static string TextureName = "character";
        public static Texture2D Texture { get; set; }
        public static Vector2 Position { get; set; }
        public static float speed = 200f;
        public static Vector2 hitbox = new Vector2(16, 30);
        public static MotionStates Motion { get; set; } = MotionStates.StandingDown;
        public static void Render(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                0f,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.End();
        }

        public static void HandleInput(KeyboardState keyState, GameTime gameTime, Map map)
        {
            Vector2 position = Position;

            if (keyState.IsKeyDown(Keys.Up))
            {
                if (HandleCollisionDetection(CollisionDirections.Up, gameTime, map))
                {

                    position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                if (HandleCollisionDetection(CollisionDirections.Down, gameTime, map))
                {
                    position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
               
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                if (HandleCollisionDetection(CollisionDirections.Left, gameTime, map)) 
                {
                    position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                if (HandleCollisionDetection(CollisionDirections.Right, gameTime, map))
                {
                    position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            Position = position;
        }

        public static bool HandleCollisionDetection(CollisionDirections direction, GameTime gameTime, Map map)
        {
            Vector2 nextPosition = Position;
            int padding = 1;

            Rectangle characterBoundingBox = new Rectangle(
                (int)(nextPosition.X - hitbox.X / 2),
                (int)(nextPosition.Y),
                (int)hitbox.X,
                (int)(hitbox.Y / 2)
            );

            switch (direction)
            {
                case CollisionDirections.Up:
                    characterBoundingBox.Y -= (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
                case CollisionDirections.Down:
                    characterBoundingBox.Y += (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
                case CollisionDirections.Left:
                    characterBoundingBox.X -= (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
                case CollisionDirections.Right:
                    characterBoundingBox.X += (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
            }

            foreach (Tile tile in map.ForegroundTiles)
            {
                Rectangle tileBoundingBox = new Rectangle(
                    (int)tile.Position.X,
                    (int)tile.Position.Y,
                    tile.Texture.Width,
                    tile.Texture.Height
                );

                if (characterBoundingBox.Intersects(tileBoundingBox))
                {
                    if (!tile.IsTraversable)
                    {
                        return false; 
                    }
                }
            }

            return true;
        }
    }
}
