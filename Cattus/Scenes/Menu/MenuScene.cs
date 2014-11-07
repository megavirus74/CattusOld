using System;
using Cattus.Scenes.Game;
using Cattus.Utils;
using CocosSharp;

namespace Cattus.Scenes.Menu {
    internal class MenuScene : CCScene {
        private readonly MenuLayer _menuLayer;
        private MenuBackgroundLayer _backgroundLayer;

        public MenuScene(CCWindow window)
            : base(window) {
            SceneResolutionPolicy = CCSceneResolutionPolicy.ShowAll;

            _backgroundLayer = new MenuBackgroundLayer();
            AddChild(_backgroundLayer);

            _menuLayer = new MenuLayer();
            AddChild(_menuLayer);

            var keyListener = new CCEventListenerKeyboard {OnKeyReleased = OnKeyReleased};

            AddEventListener(keyListener, this);
        }


        private void OnKeyReleased(CCEventKeyboard e) {
            if (e.Keys == CCKeys.Enter || e.Keys == CCKeys.Space) {
                Log.Debug("Enter//Space was pressed. Going to next scene.");
                Window.DefaultDirector.PushScene(new GameScene(Window));
            }

            if (e.Keys == CCKeys.Escape) {
                Log.Debug("Esc was pressed in Menu");
                Environment.Exit(0);
            }
        }
    }
}