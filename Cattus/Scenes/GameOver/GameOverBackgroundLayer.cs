using System.Globalization;
using Cattus.Scenes.Game;
using CocosSharp;

namespace Cattus.Scenes.GameOver {
    internal class GameOverBackgroundLayer: CCLayerColor {
        public void MenuBackgroundLayer() {
            Color = CCColor3B.Gray;
            Opacity = 20;
        }


        public override void OnEnter() {
            base.OnEnter();


            var gameOverLabel = new CCLabelTtf("Game Over!", "kongtext", 25) {
                Position = Window.WindowSizeInPixels.Center + new CCPoint(0, 20),
                IsAntialiased = false,
                AnchorPoint = CCPoint.AnchorMiddleBottom,
                Color = CCColor3B.Magenta
            };
            AddChild(gameOverLabel);

            var timeLabel = new CCLabelTtf(string.Format(CultureInfo.InvariantCulture, "Elapsed time: {0:F2} seconds\nYour score is: {1:F0}", GameLayer.GameOverTime, GameLayer.GameOverScore), "kongtext", 15) {
                                               Position = Window.WindowSizeInPixels.Center,
                                               IsAntialiased = false,
                                               AnchorPoint = CCPoint.AnchorMiddleTop,
                                               Color = CCColor3B.Gray
                                           };
            AddChild(timeLabel);

            var hintLabel = new CCLabelTtf("Press Space to restart", "kongtext", 10) {
                Position = Window.WindowSizeInPixels.Center - new CCPoint(0, 180),
                IsAntialiased = false,
                AnchorPoint = CCPoint.AnchorMiddleBottom,
                Color = CCColor3B.White
            };
            AddChild(hintLabel);
        }
    }
}