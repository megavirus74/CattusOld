using System;
using Cattus.Utils;
using CocosSharp;

namespace Cattus.Entities.Player
{
    internal class Player : Entity
    {
        /// <summary>
        /// a - ускорение
        /// MaxSpeed - макс скорость
        /// speed - текущая скорость
        /// </summary>
        private int dir = 1;
        private int speed = 0;
        private const int MaxSpeed = 400;
        private const int a = 50;

        public Player() : base(Resources.Player)
        {
            Tag = Tags.Player;
            Scale = 3;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Schedule(Update);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            Move(dt);
        }

        public void OnKeyPressed(CCKeys e)
        {
            if (e == CCKeys.Space)
            {
                InvertDir();
            }
        }

        public override void Collision(Entity other)
        {
            base.Collision(other);

            if (other.Tag == Tags.Enemy)
            {
                Window.DefaultDirector.PopScene();
                Log.Debug("Player collisiong with enemy");
            }
        }

        private void InvertDir()
        {
            dir *= -1;
        }

        public void Move(float dt)
        {
            PositionX += speed*dt;
            Log.Debug(Mask.MaxX.ToString());
            if (Mask.MaxX > Window.WindowSizeInPixels.Width-50) dir = -1;
            if (Mask.MinX < 50) dir = 1;
            
            speed += a*dir;
            if (speed > MaxSpeed)
                speed = MaxSpeed;
            if (speed < -MaxSpeed)
                speed = -MaxSpeed;

        }
    }
}