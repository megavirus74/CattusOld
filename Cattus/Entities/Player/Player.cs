using Cattus.Utils;
using CocosSharp;

namespace Cattus.Entities.Player {
    internal class Player : Entity {
        private int speed = 300;

        public Player() : base(Resources.Player) {
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
    }
}