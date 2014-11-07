namespace Cattus.Entities.Enemy {
    internal abstract class Enemy: Entity {
        protected Enemy(string url): base(url) {
            Tag = Tags.Enemy;
        }

        public override void OnEnter() {
            base.OnEnter();
            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);
            Move(dt);
        }

        /// <summary>
        /// Метод переопределяется и определяет движения врага на уровне
        /// </summary>
        public virtual void Move(float dt) {
        }
    }
}