using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cattus.Entities;
using Cattus.Entities.Enemy;
using Cattus.Entities.Player;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameLayer: CCLayer {
        public readonly List<Entity> Entities = new List<Entity>();
        public readonly Player Player;
        public Level CurLevel;

        public float GameTime = 0;
        public float LevelSpeed = 500;
        public float Score = 0;
        public static float GameOverTime;
        public static float GameOverScore;

        private bool _isRunning;

        public GameLayer() {
            Score = 0;
            GameTime = 0;

            Player = new Player(this) {
                PositionX = Settings.ScreenWidth/2,
                PositionY = Settings.StartPlayerHeight
            };
            AddEntity(Player);

            AddEntity(new Bird(new CCPoint(0, 500), this));
            AddEntity(new Bird(new CCPoint(300, 500), this));
        }

        public void OnKeyReleased(CCEventKeyboard e) {
            Player.Control(e.Keys);
        }

        public bool LoadLevel(Level level) {
            throw new NotImplementedException();
        }

        public bool TogglePauseGame() {
            _isRunning = !_isRunning;

            if (_isRunning){
                foreach (Entity ent in Entities)
                    ent.Pause();
                LevelSpeed = 0;
            }
            else{
                foreach (Entity ent in Entities)
                    ent.Resume();
                LevelSpeed = 500;
            }

            return _isRunning;
        }

        public override void OnEnter() {
            base.OnEnter();

            Schedule(Update);
            Schedule(UpdateScore, 0.1f);
        }

        public override void Update(float dt) {
            if (!_isRunning){
                base.Update(dt);
                UpdateGameTime(dt);
                UpdateCollision();
            }
        }

        private void UpdateScore(float dt) {
            Score += (LevelSpeed * dt)/50;
            LevelSpeed += 20 * dt;
        }

        private void UpdateGameTime(float dt) {
            GameTime += dt;
        }

        private void UpdateCollision() {
            // Updating collisions after 0.5 second after start
            if (GameTime > 0.5){
                foreach (Entity entity in Entities){
                    foreach (Entity entity1 in Entities){
                        if (entity.Mask.IntersectsRect(entity1.Mask) && (entity != entity1))
                        {
                            GameOverTime = GameTime;
                            GameOverScore = Score;
                            entity.Collision(entity1);
                            
                        }
                    }
                }
            }
        }


        public void AddEntity(Entity objEntity) {
            AddChild(objEntity);
            Entities.Add(objEntity);
        }

        public void RemoveEntity(Entity objEntity) {
            RemoveChild(objEntity);
            Entities.Remove(objEntity);
        }


    }
}