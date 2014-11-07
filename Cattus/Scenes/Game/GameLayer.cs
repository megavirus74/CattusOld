using System.Collections.Generic;
using Cattus.Entities;
using Cattus.Entities.Enemy;
using Cattus.Entities.Player;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameLayer: CCLayer {
        public readonly List<Entity> Entities = new List<Entity>();
        public readonly Player Player;

        public GameLayer() {
            Player = new Player {
                PositionX = Settings.ScreenWidth/2,
                PositionY = Settings.StartPlayerHeight
            };
            AddEntity(Player);

            AddEntity(new Bird(new CCPoint(0, 500)));

            AddEntity(new Bird(new CCPoint(400, 500)));
        }


        /// <summary>
        ///     Вызывается из GameScene
        /// </summary>
        public void OnKeyPressed(CCEventKeyboard e) {
            Player.Control(e.Keys);
        }


        public void AddEntity(Entity objEntity) {
            AddChild(objEntity);
            Entities.Add(objEntity);
        }

        public void RemoveEntity(Entity objEntity) {
            RemoveChild(objEntity);
            Entities.Remove(objEntity);
        }

        public override void OnEnter() {
            base.OnEnter();

            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);
            UpdateCollision();
        }

        private void UpdateCollision() {
            foreach (Entity entity in Entities){
                foreach (Entity entity1 in Entities){
                    if (entity.Mask.IntersectsRect(entity1.Mask) && (entity != entity1)){
                        entity.Collision(entity1);
                    }
                }
            }
        }
    }
}