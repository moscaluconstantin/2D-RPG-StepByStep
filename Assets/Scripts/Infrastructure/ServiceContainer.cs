using Assets.Scripts.Player;
using Assets.Scripts.UI;

namespace Assets.Scripts.Infrastructure
{
    public static class ServiceContainer
    {
        public static SaveLoad SaveLoad;
        public static SceneLoader SceneLoader;
        public static CoroutineRunner CoroutineRunner;
        public static ScreenFade ScreenFade;
        public static PlayerInventory PlayerInventory;
    }
}
