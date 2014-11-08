using System;
using Cattus.Scenes.Game;
using CocosSharp;

namespace Cattus.Entities.Enemy {
    internal class Bird: Enemy {
        private const int HSpeed = 150;
        private int _vSpeed = 0;
        private const int Amplitude = 900;
        private const int Velocity = 30;
        private int dir = -1; // 1- вверх, -1 вниз

        public Bird(CCPoint startPos, GameLayer gl): base(startPos, Resources.Bird, gl) {
        }

        public override void Move(float dt) {
            if (PositionX > Settings.ScreenWidth){
                PositionX = -32;
                _gameLayer.Score += 1;
            }
            PositionX += HSpeed*dt;

            _vSpeed += Velocity*dir;
            if (_vSpeed > Amplitude){
                _vSpeed = Amplitude;
                dir = -1;
            }
            if (_vSpeed < -Amplitude){
                _vSpeed = -Amplitude;
                dir = 1;
            }

            PositionY += _vSpeed * dt;


            //            PositionY = (float) ((5/12f)*Window.WindowSizeInPixels.Height +
            //                                 (3/8f)*Math.Sin(PositionX/Settings.ScreenWidth*12f)*Settings.ScreenHeight);
        }
    }
}