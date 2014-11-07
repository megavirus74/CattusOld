using Cattus.Utils;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameScene : CCScene {
        public CCLayer GameLayer;

        public GameScene(CCWindow window) : base(window) {
            GameLayer = new GameLayer();
            AddChild(GameLayer);

            var generalListener = new CCEventListenerKeyboard {OnKeyPressed = OnKeyPressed, OnKeyReleased = OnKeyReleased};
            AddEventListener(generalListener);
        }

        private void OnKeyPressed(CCEventKeyboard e) {
            Input.OnKeyPress(e.Keys);
        }

        private void OnKeyReleased(CCEventKeyboard e) {
            Input.OnKeyRelease(e.Keys);
            if (e.Keys == CCKeys.Escape) {
                Log.Debug("Pop out Game Scene");
                Window.DefaultDirector.PopScene();
            }
        }
    }
}