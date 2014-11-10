using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cattus.Scenes.Game;
using Cattus.Scenes.Menu;
using Cattus.Utils;
using CocosSharp;

namespace Cattus.Scenes.GameOver
{
    internal class GameOverScene: CCScene
    {
        private readonly GameOverLayer _menuLayer;
        private GameOverBackgroundLayer _backgroundLayer;

        public GameOverScene(CCWindow window)
            : base(window) {
            SceneResolutionPolicy = CCSceneResolutionPolicy.ShowAll;

            _backgroundLayer = new GameOverBackgroundLayer();
            AddChild(_backgroundLayer);

            _menuLayer = new GameOverLayer();
            AddChild(_menuLayer);

            var keyListener = new CCEventListenerKeyboard {OnKeyReleased = OnKeyReleased};

            AddEventListener(keyListener, this);
        }

    
        private void OnKeyReleased(CCEventKeyboard e) {
            if (e.Keys == CCKeys.Enter || e.Keys == CCKeys.Space){
                Log.Debug("Enter//Space was pressed. Going to next scene.");
                Window.DefaultDirector.PushScene(new GameScene(Window));
            }

            if (e.Keys == CCKeys.Escape){
                Log.Debug("Esc was pressed in Game Over Scene");
                Environment.Exit(0);
            }
        }
    }
}
