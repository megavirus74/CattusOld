using Cattus.Scenes.Game;
using Cattus.Scenes.GameOver;
using CocosSharp;

namespace Cattus.Entities.Player {
    internal class Player: Entity {
        private const int MaxSpeed = 400;

        /// velocity - ускорение
        private const int Velocity = 50;

        //   направление движения. 1 - вправо, -1 - влево
        private int _dir = 1;

        //  текущая скорость
        private int _speed;

        private GameLayer _gameLayer;


        public Player(GameLayer gl): base(Resources.Player) {
            _gameLayer = gl;

            Tag = Tags.Player;
        }

        public override void OnEnter() {
            base.OnEnter();
            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);
            UpdateImage();
            Move(dt);
        }

        private void UpdateImage() {
            if (_speed > 0){
                FlipX = false;
            }
            else{
                FlipX = true;
            }
        }

        public void Control(CCKeys e) {
            if (e == CCKeys.Space){
                InvertDir();
            }
        }

        public override void Collision(Entity other) {
            base.Collision(other);

            if (other.Tag == Tags.Enemy){
//                _gameLayer.Score -= 1;

                Window.RunWithScene(new GameOverScene(Window));
            }
        }

        private void InvertDir() {
            _dir *= -1;
        }

        public void Move(float dt) {
            PositionX += _speed*dt;

            if (Mask.MaxX > Window.WindowSizeInPixels.Width - 50) _dir = -1;
            if (Mask.MinX < 50) _dir = 1;

            _speed += Velocity*_dir;
            if (_speed > MaxSpeed)
                _speed = MaxSpeed;
            if (_speed < -MaxSpeed)
                _speed = -MaxSpeed;
        }
    }
}