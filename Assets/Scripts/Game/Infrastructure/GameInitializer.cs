using System;
using Game.Application.Interfaces;
using Game.Domain.Entities;
using UnityEngine;

namespace Game.Infrastructure
{
    public class GameInitializer : IGameInitializer
    {
        public void Initialize(GameMode mode)
        {
            switch (mode)
            {
                case GameMode.Easy:
                    Debug.Log("Easy");
                    //SaveManager.SaveGameMode(GameMode.Easy);
                    break;
                case GameMode.EasyMedium:
                    Debug.Log("EasyMedium");
                    //SaveManager.SaveGameMode(GameMode.EasyMedium);
                    break;
                case GameMode.Medium:
                    Debug.Log("Medium");
                    //SaveManager.SaveGameMode(GameMode.Medium);
                    break;
                case GameMode.MediumHard:
                    Debug.Log("MediumHard");
                    //SaveManager.SaveGameMode(GameMode.MediumHard);
                    break;
                case GameMode.Hard:
                    Debug.Log("Hard");
                    //SaveManager.SaveGameMode(GameMode.Hard);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}