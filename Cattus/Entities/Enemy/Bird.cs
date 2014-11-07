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

        }
    }
}
