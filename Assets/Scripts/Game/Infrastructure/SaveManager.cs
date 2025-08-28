using Game.Domain.Entities;
using UnityEngine;

namespace Game.Infrastructure
{
    public class SaveManager
    {
        private static SaveManager _instance;
        private static readonly object Lock = new object();
        private const string GameModeKey = "GameConfigKey";

        public static SaveManager Singleton
        {
            get
            {
                lock (Lock)
                {
                    return _instance ??= new SaveManager();
                }
            }
        }

        public static void SaveGameMode(GameModeConfig gameConfigToSave)
        {
            var saveGameData = JsonUtility.ToJson(gameConfigToSave);
            Debug.Log(">>>>> " + saveGameData);
            PlayerPrefs.SetString(GameModeKey, saveGameData);
            PlayerPrefs.Save();
        }

        public static GameModeConfig LoadGameMode()
        {
            var savedGameConfig = PlayerPrefs.GetString(GameModeKey, null);
            return JsonUtility.FromJson<GameModeConfig>(savedGameConfig);
        }
    }
}