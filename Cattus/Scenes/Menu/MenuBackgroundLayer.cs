using CocosSharp;

namespace Cattus.Scenes.Menu {
    internal class MenuBackgroundLayer : CCLayerColor {
        public MenuBackgroundLayer() {
            Color = CCColor3B.Blue;
            Opacity = 20;
        }
    }
}