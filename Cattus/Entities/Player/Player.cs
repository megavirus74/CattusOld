using Cattus.Utils;
using CocosSharp;

namespace Cattus.Entities.Player {
    internal class Player : Entity {
        private int speed = 300;

        public Player() : base(Resources.Player)
        {
            Tag = Tags.Player;
        }

        public void Control(float dt) {
            if (Input.IsKeyIn(CCKeys.Left))
            {
                PositionX -= speed*dt;
            }

            if (Input.IsKeyIn(CCKeys.Right))
            {
                PositionX += speed*dt;
            }
            if (Input.IsKeyIn(CCKeys.Up)) {
                PositionY += speed * dt;
            }

            if (Input.IsKeyIn(CCKeys.Down)) {
                PositionY -= speed * dt;
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
    }
}