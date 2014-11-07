﻿using System;
﻿using Cattus.Utils;
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

        private int speed = 200;
        private int pos = 1;
        private static int count = 0;
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
            if (PositionX > Settings.ScreenWidth)
            {
                PositionX = -32;
                count++;
                Log.Debug(count.ToString());
            }
            PositionX += speed * dt*pos;

            PositionY = (float) ((5/12f)*Window.WindowSizeInPixels.Height +
                                 (3/8f)*Math.Sin(PositionX / Settings.ScreenWidth*12f)*Settings.ScreenHeight);
        }
    }
}
