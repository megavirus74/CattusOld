using Cattus.Utils;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameScene: CCScene {
        public GameBackground GameBackground;
        public GameLayer GameLayer;
        public GameGui GameGui;

        public GameScene(CCWindow window): base(window) {
            GameBackground = new GameBackground();
            AddChild(GameBackground);

            GameLayer = new GameLayer();
            AddChild(GameLayer);

            GameGui = new GameGui(GameLayer);
            AddChild(GameGui);

            var generalListener = new CCEventListenerKeyboard {
                OnKeyPressed = OnKeyPressed,
                OnKeyReleased = OnKeyReleased
            };
            AddEventListener(generalListener);
        }

        private void OnKeyPressed(CCEventKeyboard e) {
            Input.OnKeyPress(e.Keys);

            GameLayer.OnKeyPressed(e);
        }

        private void OnKeyReleased(CCEventKeyboard e) {
            Input.OnKeyRelease(e.Keys);

            if (e.Keys == CCKeys.Escape){
                Log.Debug("Pop out Game Scene");
                Window.DefaultDirector.PopScene();
            }
        }
    }
}