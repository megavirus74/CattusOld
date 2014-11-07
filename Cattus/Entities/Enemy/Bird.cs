using System;
using CocosSharp;

namespace Cattus.Entities.Enemy {
    internal class Bird: Enemy {
        private const int speed = 150;

        public Bird(CCPoint startPos): base(startPos, Resources.Bird) {
        }

        public override void Move(float dt) {
            if (PositionX > Settings.ScreenWidth){
                PositionX = -32;
            }
            PositionX += speed*dt;

            PositionY = (float) ((5/12f)*Window.WindowSizeInPixels.Height +
                                 (3/8f)*Math.Sin(PositionX/Settings.ScreenWidth*12f)*Settings.ScreenHeight);
        }
    }
}