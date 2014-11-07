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

        List<Entity> entities=new List<Entity>();
        public GameLayer() {
            player = new Player() {
                PositionX = 400,
                PositionY = 300
            };
            AddEntity(new Wall(){Position = new CCPoint(200, 200)});
            AddEntity(player);
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
            player.Control(dt);
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