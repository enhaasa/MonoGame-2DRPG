using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace ArrPeeGee.Entities
{
    internal class Character
    {
        public enum Direction
        {
            Up,
            Down, 
            Left,
            Right,
        }
        public Vector2 Position { get; set; }
        private SpriteBatch SpriteBatch { get; set; }
        private Vector2 hitbox = new Vector2(35, 77);
        private float speed = 200f;
        public Animator animator;

        public Character(SpriteBatch spriteBatch, Texture2D spriteSheet, Vector2 position) 
        {
            this.SpriteBatch = spriteBatch;
            this.Position = position;
            this.animator = new Animator(spriteSheet);

            // Default stance
            animator.State = AnimationState.StandingDown;
        }

        public void Render(GameTime gameTime)
        {
            animator.AnimateLoop(gameTime, SpriteBatch, Position);
        }

        public void Idle(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    animator.State = AnimationState.StandingUp;
                    break;
                case Direction.Down:
                    animator.State = AnimationState.StandingDown;
                    break;
                case Direction.Left:
                    animator.State = AnimationState.StandingLeft;
                    break;
                case Direction.Right:
                    animator.State = AnimationState.StandingRight;
                    break;
            }
        }

        public void Walk(Direction direction, GameTime gameTime, Map map)
        {
            Vector2 position = Position;

            // Handle movement
            switch (direction)
            {
                case Direction.Up:
                    if (HandleCollisionDetection(Direction.Up, gameTime, map))
                    {
                        position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    break;

                case Direction.Down:
                    if (HandleCollisionDetection(Direction.Down, gameTime, map))
                    {
                        position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    break;

                case Direction.Left:
                    if (HandleCollisionDetection(Direction.Left, gameTime, map))
                    {
                        position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    break;
                case Direction.Right:
                    if (HandleCollisionDetection(Direction.Right, gameTime, map))
                    {
                        position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    break;
            }

      
            // Handle animation
            if (direction == Direction.Up) {
                animator.State = AnimationState.WalkingUp;
            } else if (direction == Direction.Down) {
                animator.State = AnimationState.WalkingDown;
            } else if (direction == Direction.Left) {
                animator.State = AnimationState.WalkingLeft;
            } else if (direction == Direction.Right) {
                animator.State = AnimationState.WalkingRight;
            }

            Position = position;
        }

        private bool HandleCollisionDetection(Direction direction, GameTime gameTime, Map map)
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
                case Direction.Up:
                    characterBoundingBox.Y -= (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
                case Direction.Down:
                    characterBoundingBox.Y += (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
                case Direction.Left:
                    characterBoundingBox.X -= (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds + padding);
                    break;
                case Direction.Right:
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


