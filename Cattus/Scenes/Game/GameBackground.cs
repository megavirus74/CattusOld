using CocosSharp;
using Microsoft.Xna.Framework.Graphics;

namespace Cattus.Scenes.Game {
    internal class GameBackground: CCLayerColor {

        private CCSprite _levelImage;

        private readonly GameLayer _gameLayer;
        public GameBackground(GameLayer gl) {
            Color = CCColor3B.Blue;
            Opacity = 50;
            AnchorPoint = CCPoint.AnchorUpperLeft;

            _gameLayer = gl;
        }

        public override void OnEnter() {
            base.OnEnter();

            _levelImage = new CCSprite(Resources.TestBG) {
                Position = Window.WindowSizeInPixels.Center,
            };
            AddChild(_levelImage);

            /** Добавление этих же картиной сверху и снизу от основной для непрерывности */
            /** TODO: Временно, удалить*/
            var sameImage = new CCSprite(Resources.TestBG);
            sameImage.PositionX = sameImage.Texture.PixelsWide/2;
            sameImage.PositionY = 3*sameImage.Texture.PixelsHigh/2;
            _levelImage.AddChild(sameImage);

            sameImage = new CCSprite(Resources.TestBG);
            sameImage.PositionX = sameImage.Texture.PixelsWide / 2;
            sameImage.PositionY = -sameImage.Texture.PixelsHigh/2;
            _levelImage.AddChild(sameImage);

            
            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);
            UpdateBG(dt);
        }

        private void UpdateBG(float dt) {
            _levelImage.PositionY -= _gameLayer.LevelSpeed*dt;

            if (_levelImage.PositionY + _levelImage.Texture.PixelsHigh/2 < 0){
                _levelImage.PositionY = _levelImage.Texture.PixelsHigh + _levelImage.Texture.PixelsHigh / 2;
            }
        }
    }
}