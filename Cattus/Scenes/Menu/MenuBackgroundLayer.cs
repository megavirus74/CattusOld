using System.Reflection.Emit;
using CocosSharp;

namespace Cattus.Scenes.Menu {
    internal class MenuBackgroundLayer : CCLayerColor {
        public MenuBackgroundLayer() {
            Color = CCColor3B.Blue;
            Opacity = 20;

            
        }

        public override void OnEnter() {
            base.OnEnter();
            var gameLabel = new CCLabelTtf(Settings.GameName, "kongtext", 40) {
                Position = Window.WindowSizeInPixels.Center + new CCPoint(0, 130),
                IsAntialiased = false,
                AnchorPoint = CCPoint.AnchorMiddleBottom
            };
            AddChild(gameLabel);

            var hintLabel = new CCLabelTtf("press space to start!", "kongtext", 15) {
                Position = Window.WindowSizeInPixels.Center,
                IsAntialiased = false,
                AnchorPoint = CCPoint.AnchorMiddleTop,
                Color = CCColor3B.Gray
            };
            AddChild(hintLabel);
        }
    }
}