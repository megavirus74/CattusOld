using Cattus.Utils;
using CocosSharp;

namespace Cattus {
    internal class Resources {
        public const string Player = "Player.png";
        public const string Wall = "Wall.png";

        /** Добавляет в пути поиска ресурсов необходимые папки */

        public static void LoadContent(CCApplication application) {
            Log.Info("Loading resources");
            application.ContentRootDirectory = "Resource";

            CCSpriteFontCache.DefaultFont = "kongtext";

            application.ContentSearchPaths.Add("Font");
            application.ContentSearchPaths.Add("Icon");
            application.ContentSearchPaths.Add("Image");
            application.ContentSearchPaths.Add("Image\\Player");
            application.ContentSearchPaths.Add("Image\\Enemy");
            application.ContentSearchPaths.Add("Image\\Effects");
            application.ContentSearchPaths.Add("Image\\GUI");
            application.ContentSearchPaths.Add("Music");
            application.ContentSearchPaths.Add("Sound");

            CCSpriteFontCache.FontScale = 1f;
            CCSpriteFontCache.RegisterFont("arial", 24);
        }
    }
}