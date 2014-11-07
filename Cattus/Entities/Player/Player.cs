using Cattus.Utils;
using CocosSharp;

namespace Cattus.Entities.Player {
    internal class Player : Entity {
        private int speed = 300;
        private int dir = 1;
        public Player() : base(Resources.Player)
        {
            Tag = Tags.Player;
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

        public void OnKeyPressed(CCKeys e) {
            if (e == CCKeys.Space)
            {
                dir = dir*(-1);
            }
        }

        public override void Collision(Entity other)
        {
            base.Collision(other);

            if (other.Tag == Tags.Enemy)
            {
                Log.Debug("Player collisiong with wall");
            }
        }

        public void Move(float dt)
            {
                PositionX += speed*dt*dir;
            if (PositionX > Window.WindowSizeInPixels.Width) dir = -1;
            if (PositionX < 0) dir = 1;
            }
    }
}