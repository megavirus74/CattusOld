using System;

namespace Cattus.Entities.Enemy {
    internal class Bird: Enemy {
        private int pos = 1;
        private int speed = 200;

        public Bird(): base(Resources.Bird) {
        }

        public override void Move(float dt) {
            if (PositionX > Settings.ScreenWidth){
                PositionX = -32;
            }
            PositionX += speed*dt*pos;

            PositionY = (float) ((5/12f)*Window.WindowSizeInPixels.Height +
                                 (3/8f)*Math.Sin(PositionX/Settings.ScreenWidth*12f)*Settings.ScreenHeight);
        }
    }
}