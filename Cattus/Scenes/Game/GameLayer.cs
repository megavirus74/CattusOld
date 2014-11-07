using System.Collections.Generic;
using Cattus.Entities;
using Cattus.Entities.Enemy;
using Cattus.Entities.Player;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameLayer: CCLayer {
        public readonly List<Entity> Entities = new List<Entity>();
        public readonly Player Player;

        /** Game stats */
        public int Score = 0;
        public float GameTime;

        
        public GameLayer() {

            Score = 0;
            GameTime = 0;

            Player = new Player(this) {
                PositionX = Settings.ScreenWidth/2,
                PositionY = Settings.StartPlayerHeight
            };
            AddEntity(Player);

            AddEntity(new Bird(new CCPoint(0, 500), this));

            AddEntity(new Bird(new CCPoint(400, 500), this));
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
            UpdateGameTime(dt);
            UpdateCollision();
        }

        private void UpdateGameTime(float dt) {
            GameTime += dt;
        }

        private void UpdateCollision() {
            // Updating collisions after 0.5 second after start
            if (GameTime > 0.5) {
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
}