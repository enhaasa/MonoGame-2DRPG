using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrPeeGee
{
    public enum AnimationState
    {
        StandingUp,
        StandingDown,
        StandingLeft,
        StandingRight,
        WalkingUp,
        WalkingDown,
        WalkingLeft,
        WalkingRight,
    }
    internal class Animator
    {
        private Texture2D SpriteSheet { get; set; }
        private double ElapsedTime { get; set; }
        public int CurrentFrameIndex { get; set; }

        private Animation[] _animations = new Animation[] {
            new Animation(AnimationState.StandingUp,
                new List<Rectangle>
                {
                    new Rectangle(108, 0, 35, 77),
                }, 0.2
            ),
            new Animation(AnimationState.StandingDown,
                new List<Rectangle>
                {
                    new Rectangle(0, 0, 35, 77),
                }, 0.2
            ),
            new Animation(AnimationState.StandingLeft,
                new List<Rectangle>
                {
                    new Rectangle(0, 77, 35, 77),
                }, 0.2
            ),
            new Animation(AnimationState.StandingRight,
                new List<Rectangle>
                {
                    new Rectangle(115, 77, 35, 77),
                }, 0.2
            ),
            new Animation(
                AnimationState.WalkingUp,
                new List<Rectangle>
                {
                    new Rectangle(108, 0, 35, 77),
                    new Rectangle(142, 0, 35, 77),
                    new Rectangle(108, 0, 35, 77),
                    new Rectangle(179, 0, 35, 77),
                }, 0.2
            ),
            new Animation(
                AnimationState.WalkingDown,
                new List<Rectangle>
                {
                    new Rectangle(0, 0, 35, 77),
                    new Rectangle(36, 0, 35, 77),
                    new Rectangle(0, 0, 35, 77),
                    new Rectangle(72, 0, 35, 77),
                }, 0.2
             ),
             new Animation(
                AnimationState.WalkingLeft,
                new List<Rectangle>
                {
                    new Rectangle(0, 77, 35, 77),
                    new Rectangle(33, 77, 41, 77),
                    new Rectangle(0, 77, 35, 77),
                    new Rectangle(74, 77, 41, 77),
                }, 0.2
             ),
             new Animation(
                AnimationState.WalkingRight,
                new List<Rectangle>
                {
                    new Rectangle(115, 77, 35, 77),
                    new Rectangle(151, 77, 41, 77),
                    new Rectangle(115, 77, 35, 77),
                    new Rectangle(192, 77, 41, 77),
                }, 0.2
             ),

        };
        private Animation _animation;
        private AnimationState _state;
        public AnimationState State
        {
            get { return _state; }
            set
            {
                if (value != _state)
                {
                    _state = value;
                    _animation = GetAnimation(value);
                    CurrentFrameIndex = 0;
                }
            }
        }

        public Animation GetAnimation(AnimationState state)
        {
            return _animations.FirstOrDefault(a => a.State == state);
        }

        public Animator(Texture2D spriteSheet) { 
            this.SpriteSheet = spriteSheet;
        }

        public void AnimateLoop(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position)
        {
            if (ElapsedTime > _animation.Speed)
            {

                if (CurrentFrameIndex >= _animation.Frames.Count - 1)
                {
                    CurrentFrameIndex = 0;
                }
                else
                {
                    CurrentFrameIndex++;
                }

                ElapsedTime = 0;
            }

            ElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            Rectangle currentFrame = _animation.Frames[CurrentFrameIndex];

            spriteBatch.Begin();
            spriteBatch.Draw(
                SpriteSheet,
                position,
                currentFrame,
                Color.White,
                0f,
                new Vector2(currentFrame.Width / 2, currentFrame.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            spriteBatch.End();
        }
    }

    internal class Animation
    {
        public List<Rectangle> Frames { get; set; }
        public double Speed { get; set; }
        public AnimationState State { get; set; }
        public Animation(AnimationState state, List<Rectangle> frames, double speed)
        {
            State = state;
            Frames = frames;
            Speed = speed;
        }
    }
}
