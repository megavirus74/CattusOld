using Cattus.Entities.Player;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameLayer : CCLayer {
        private Player player;
        public GameLayer() {
            player = new Player() {
                PositionX = 400,
                PositionY = 300
            };

            AddChild(player);

        }


        public override void OnEnter() {
            base.OnEnter();

            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);

            player.Control(dt);
        }
    }
}