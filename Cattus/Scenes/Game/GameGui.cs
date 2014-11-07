using System.Globalization;
using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameGui: CCLayer {
        // Берет всю информацию с игрового слоя
        private readonly GameLayer _gameLayer;

        

        private const string ScoreText = "SCORE: {0}";
        private CCLabelTtf _scoreLabel;

        private const string TimeText = "Time: {0:F2}";
        private CCLabelTtf _timeLabel;

        public GameGui(GameLayer gl) {
            _gameLayer = gl;
        }

        public override void OnEnter() {
            base.OnEnter();
            Schedule(Update);

            _scoreLabel = new CCLabelTtf("", "kongtext", 14) {
                PositionX = 20,
                PositionY = Window.WindowSizeInPixels.Height - 20,
                AnchorPoint = CCPoint.AnchorUpperLeft,
                Color = CCColor3B.Orange
            };
            AddChild(_scoreLabel);

            _timeLabel = new CCLabelTtf("", "kongtext", 14) {
                PositionX = 20,
                PositionY = Window.WindowSizeInPixels.Height - 50,
                AnchorPoint = CCPoint.AnchorUpperLeft,
                Color = CCColor3B.Orange
            };
            AddChild(_timeLabel);

        }

        public override void Update(float dt) {
            base.Update(dt);
            _scoreLabel.Text = string.Format(ScoreText, _gameLayer.Score);
            _timeLabel.Text = string.Format(CultureInfo.InvariantCulture, TimeText, _gameLayer.GameTime);
        }
    }
}