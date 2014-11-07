using Cattus.Scenes.Game;
using CocosSharp;

namespace Cattus.Entities.Enemy {
    internal abstract class Enemy: Entity {
        protected GameLayer _gameLayer;

        protected Enemy(CCPoint startPos, string url, GameLayer gl): base(url) {
            Tag = Tags.Enemy;
            Position = startPos;
            _gameLayer = gl;
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
        ///     Метод переопределяется и определяет движения врага на уровне
        /// </summary>
        public virtual void Move(float dt) {
        }
    }
}