using System;
using System.Collections.Generic;
using Cattus.Entities.Enemy;

namespace Cattus.Scenes.Game {
    internal class Pattern {

        public bool IsFinished = false;

        // Enemy - враг, который создаётся. int - время, через сколько создается после старта
        // TODO: Или по другому создавать? нужно посмотреть и подумать :)
        Dictionary<Enemy, int> _enemies = new Dictionary<Enemy, int>();

        public void AddEnemy(Enemy enemt, int time) {
            throw new NotImplementedException();
        }

        public void Logic() {
            throw new NotImplementedException();
        }
    }
}