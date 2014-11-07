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
            PositionY -= speed * dt;

            if (PositionY < 0)
            {
                Position = new CCPoint(0, 500);
                speed += 50;
            }
        }
    }
}
