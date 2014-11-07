using CocosSharp;

namespace Cattus.Scenes.Game {
    internal class GameGui: CCLayer {
        // Берет всю информацию с игрового слоя
        private readonly GameLayer _gameLayer;

        private const string ScoreText = "SCORE: {0}";
        private CCLabelTtf _scoreLabel;



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
        }

        public override void Update(float dt) {
            base.Update(dt);
            _scoreLabel.Text = string.Format(ScoreText, _gameLayer.Score);
        }
    }
}