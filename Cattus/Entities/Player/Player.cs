using CocosSharp;

namespace Cattus.Entities.Player {
    internal class Player: Entity {
        private const int MaxSpeed = 400;
        private const int Velocity = 50;

        /// <summary>
        ///     _dir - направление движения. 1 - вправо, -1 - влево
        ///     velocity - ускорение
        ///     MaxSpeed - макс скорость
        ///     _speed - текущая скорость
        /// </summary>
        private int _dir = 1;

        private int _speed;

        public Player(): base(Resources.Player) {
            Tag = Tags.Player;
            Scale = 3;
        }

        public override void OnEnter() {
            base.OnEnter();
            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);
            Move(dt);
        }

        public void Control(CCKeys e) {
            if (e == CCKeys.Space){
                InvertDir();
            }
        }

        public override void Collision(Entity other) {
            base.Collision(other);

            if (other.Tag == Tags.Enemy){
                Window.DefaultDirector.PopScene();
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