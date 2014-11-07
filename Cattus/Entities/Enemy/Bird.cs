using System;
using CocosSharp;

namespace Cattus.Entities.Enemy
{
    internal class Bird : Entity
    {
        public Bird()
            : base(Resources.Bird)
        {
            Tag = Tags.Enemy;
        }
        private int speed = 180;
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
        public void Move(float dt)
        {
            PositionX += speed * dt;
            if (PositionX > Settings.ScreenWidth)
            {
                PositionX = -32;
            }
          
            PositionY = (float) ((5/12f)*Window.WindowSizeInPixels.Height +
                                 (3/8f)*Math.Sin(PositionX / Settings.ScreenWidth*12f)*Settings.ScreenHeight);
        }
    }
}
