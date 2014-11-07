using System.Collections.Generic;
using System.Data;
using Cattus.Entities;
using Cattus.Entities.Enemy;
using Cattus.Entities.Player;
using Cattus.Utils;
using CocosSharp;
using SharpDX;
using SharpDX.Direct3D11;

namespace Cattus.Scenes.Game {
    internal class GameLayer : CCLayer {
        private Player player;
        private Bird bird;

        List<Entity> entities=new List<Entity>();
        public GameLayer() {
            player = new Player() {
                PositionX = Settings.ScreenWidth/2,
                PositionY = 200
            };
            AddEntity(player);

            bird = new Bird()
            {
                PositionX = 0,
                PositionY = 500
            };
            AddEntity(bird);

            AddEntity(new Bird()
            {
                PositionX = Settings.ScreenWidth/2+120,
                PositionY = 500
            });



            var listener = new CCEventListenerKeyboard { OnKeyPressed = OnKeyPressed };
            AddEventListener(listener);
        }


        private void OnKeyPressed(CCEventKeyboard e)
        {
            player.OnKeyPressed(e.Keys);
        }


        public void AddEntity(Entity objEntity)
        {
            AddChild(objEntity);
            entities.Add(objEntity);
        }

        public void RemoveEntity(Entity objEntity)
        {
            RemoveChild(objEntity);
            entities.Remove(objEntity);
        }

        public override void OnEnter() {
            base.OnEnter();

            Schedule(Update);
            
           
        }

        public override void Update(float dt) {
            base.Update(dt);
            UpdateCollision();
        } 

        private void UpdateCollision()
        {
            foreach (var entity in entities)
            {
                foreach (var entity1 in entities)
                {
                    if (entity.Mask.IntersectsRect(entity1.Mask) && (entity != entity1))
                    {
                        entity.Collision(entity1);
                    }
                }
            }
        }
    }
}