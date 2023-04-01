namespace Assets.Scripts.Infrastructure
{
    public class SaveLoad
    {
        public PlayerData PlayerData { get; private set; }

        public SaveLoad()
        {
            PlayerData = new PlayerData();

            Load();
        }

        public void Load()
        {
            //load player data
        }

        public void Save()
        {
        }

    }
}
