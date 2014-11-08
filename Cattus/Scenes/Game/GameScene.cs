using Cattus.Utils;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameScene: CCScene {
        public GameBackground GameBackground;
        public GameLayer GameLayer;
        public GameGui GameGui;

        public GameScene(CCWindow window): base(window) {
            GameLayer = new GameLayer();
            AddChild(GameLayer, 0);

            GameBackground = new GameBackground(GameLayer);
            AddChild(GameBackground, -5);

            GameGui = new GameGui(GameLayer);
            AddChild(GameGui, 5);

            var generalListener = new CCEventListenerKeyboard {
                OnKeyPressed = OnKeyPressed,
                OnKeyReleased = OnKeyReleased
            };
            AddEventListener(generalListener);
        }

        private void OnKeyPressed(CCEventKeyboard e) {
            Input.OnKeyPress(e.Keys);
        }

        private void OnKeyReleased(CCEventKeyboard e) {
            Input.OnKeyRelease(e.Keys);

            GameLayer.OnKeyReleased(e);

            if (e.Keys == CCKeys.Escape){
                Log.Debug("Pop out Game Scene");
                Window.DefaultDirector.PopScene();
            }
        }
    }
}