using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameBackground: CCLayerColor {
        public GameBackground() {
            Color = CCColor3B.Blue;
            Opacity = 50;
        }
    }
}