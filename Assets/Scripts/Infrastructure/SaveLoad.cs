using Assets.Scripts.Constants;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class SaveLoad
    {
        public PlayerData PlayerData { get; private set; }

        public SaveLoad() =>
            Load();

        public void Load()
        {
            PlayerData = new PlayerData()
            {
                SceneName = Load(SaveKeys.SCENE_NAME, "Countryside"),
                TransitionKey = Load(SaveKeys.TRANSITION_KEY, "initial")
            };

            Debug.Log("Loaded.");
        }

        public bool Load(string key, bool defaultValue)
        {
            int loaded = Load(key, -1);

            if (loaded == -1)
                return defaultValue;

            return loaded != 0;
        }

        public int Load(string key, int defaultValue)
        {
            if (!PlayerPrefs.HasKey(key))
                return defaultValue;

            return PlayerPrefs.GetInt(key);
        }

        public float Load(string key, float defaultValue)
        {
            if (!PlayerPrefs.HasKey(key))
                return defaultValue;

            return PlayerPrefs.GetFloat(key);
        }

        public string Load(string key, string defaultValue)
        {
            if (!PlayerPrefs.HasKey(key))
                return defaultValue;

            return PlayerPrefs.GetString(key);
        }

        public void Save()
        {
            Save(SaveKeys.SCENE_NAME, PlayerData.SceneName);
            Save(SaveKeys.TRANSITION_KEY, PlayerData.TransitionKey);

            Debug.Log("Saved.");
        }

        public void Save(string key, bool value) =>
            Save(key, value ? 1 : 0);

        public void Save(string key, int value) =>
            PlayerPrefs.SetInt(key, value);

        public void Save(string key, float value) =>
            PlayerPrefs.SetFloat(key, value);

        public void Save(string key, string value) =>
            PlayerPrefs.SetString(key, value);

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Cleared.");
        }
    }
}
