using Cattus.Utils;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameScene : CCScene {
        public CCLayer GameLayer;

        public GameScene(CCWindow window) : base(window) {
            GameLayer = new GameLayer();
            AddChild(GameLayer);

            var generalListener = new CCEventListenerKeyboard {OnKeyReleased = OnKeyReleased};
            AddEventListener(generalListener);
        }


        private void OnKeyReleased(CCEventKeyboard e) {
            if (e.Keys == CCKeys.Escape) {
                Log.Debug("Pop out Game Scene");
                Window.DefaultDirector.PopScene();
            }
        }
    }
}