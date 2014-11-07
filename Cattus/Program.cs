using Cattus.Utils;
using CocosSharp;

namespace Cattus {
    internal class Program {
        private static void Main(string[] args) {
            Log.Info(string.Format("Starting {0} Game!", Settings.GameName));

            var application = new CCApplication(false, new CCSize(Settings.ScreenWidth, Settings.ScreenHeight)) {
                ApplicationDelegate = new Game()
            };
            application.StartGame();
        }
    }
}