using Cattus.Scenes.Game;
using CocosSharp;

namespace Cattus.Entities.Enemy {
    internal class Wall: Enemy {
        public Wall(CCPoint startPos, GameLayer gl)
            : base(startPos, Resources.Wall, gl) {
            Tag = Tags.Enemy;
        }
    }
}