using Cattus.Utils;
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
        private int count = 0;
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
            PositionX += speed * dt*pos;
            PositionY -= speed*dt;

            if (PositionY < 0)
            {
                Position = new CCPoint(Settings.ScreenWidth / 2 + Settings.ScreenWidth / 2 * pos, 500);
                speed += 50;
                pos *= -1;
                count++;
                Log.Debug(count.ToString());
            }
        }
    }
}
