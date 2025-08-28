using Game.Domain.Entities;
using UnityEngine;

namespace Game.Infrastructure
{
    public class SaveManager
    {
        private static SaveManager _instance;
        private static readonly object Lock = new object();
        private const string GameModeKey = "GameModeKey";

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

        public static void SaveGameMode(GameMode gameModeToSave)
        {
            PlayerPrefs.SetInt(GameModeKey, (int)gameModeToSave);
            PlayerPrefs.Save();
        }

        public GameMode LoadGameMode()
        {
            var savedGameModeInt = PlayerPrefs.GetInt(GameModeKey, 0);
            return (GameMode)savedGameModeInt;
        }
    }
}