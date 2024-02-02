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
    internal static class Player
    {
        public static string TextureName = "character";
        public static Texture2D Texture {  get; set; }
        public static Vector2 Position { get; set; }
        public static float speed = 200f;
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
                
                position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            Position = position;
        }

        public static void HandleCollisionDetection(CollisionDirections direction, GameTime gameTime, Map map)
        {
            Vector2 nextPosition = Position;

            switch(direction)
            {
                case CollisionDirections.Up:
                    nextPosition.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds + Texture.Height / 2;
                    break;
                case CollisionDirections.Down:
                    nextPosition.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case CollisionDirections.Left:
                    nextPosition.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case CollisionDirections.Right:
                    nextPosition.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }

            //Tile adjacentTile = null;
            Console.WriteLine("nextPosition: " + nextPosition);

            /*
            foreach (Tile tile in Foreground.tiles[map.ForegroundTileMap])
            {
                
                if (nextPosition.X < tile.Position.X + tile.Texture.Width && Position.X > tile.Position.X)
                {
                    Console.WriteLine("Found a tile within the same X coordinate");

                    if (nextPosition.Y < tile.Position.Y + tile.Texture.Height && Position.Y > tile.Position.Y)
                    {
                        Console.WriteLine("Next tile is within the same Y coordinate");
                        adjacentTile = tile;
                        break;
                    }
                }
            }


            if (adjacentTile == null)
            {
                return false;
            }

            if (adjacentTile.IsTraversable)
            {
                return true;
            } else
            {
                return false;
            }
            */
        }
            


    }

}
