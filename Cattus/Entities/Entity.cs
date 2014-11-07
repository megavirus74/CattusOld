using System;
using Cattus.Utils;
using CocosSharp;

namespace Cattus.Entities {
    internal abstract class Entity : CCSprite {
        protected int _maskW;
        protected int _maskH;

        protected Entity(string url) : base(url) {
            UpdateMaskSize();
        }

        public CCRect Mask { get; protected set; }

        public void UpdateMaskSize()
        {
            _maskW = (int)(Texture.PixelsWide * ScaleX);
            _maskH = (int)(Texture.PixelsHigh * ScaleY);
        }

        public override void OnEnter() {
            base.OnEnter();

            Schedule(Update);
        }

        public override void Update(float dt) {
            base.Update(dt);
            UpdateMask();
        }
        
        protected virtual void UpdateMask()
        {
            UpdateMaskSize();
            Mask = new CCRect(PositionX - (_maskW/2),
                PositionY - (_maskH/2), _maskW, _maskH);
//            Log.Debug(Mask + " PLAYER POS " + Position);
        }

        /// <summary>
        ///     Метод вызывается при столкновении двух объектов.
        /// </summary>
        /// <param name="other"> Объект с которым произошло столкновение </param>
        public virtual void Collision(Entity other) {

        }


        public static CCPoint GetNormalPointByDirection(float dir) {
            var x = (float) Math.Cos(ToRadians(dir));
            var y = (float) Math.Sin(ToRadians(dir));
            return new CCPoint(x, y);
        }

        public static float DistanceBetweenPoints(CCPoint p1, CCPoint p2) {
            return (float) (Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow(p2.Y - p1.Y, 2)));
        }

        public static float ToRadians(float angle) {
            return (float) ((Math.PI/180)*angle);
        }
    }
}