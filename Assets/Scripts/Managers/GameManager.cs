using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameMode gameMode;

    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //
        InitializeGameManager();
    }

    private void InitializeGameManager()
    {
        gameMode = SaveManager.Singleton.LoadGameMode();
    }

    public void SaveGameMode(GameMode gameModeToSave)
    {
        gameMode = gameModeToSave;
        SaveManager.Singleton.SaveGameMode(gameMode);
    }

    public void LoadGameMode()
    {
        gameMode = SaveManager.Singleton.LoadGameMode();
        Debug.Log("Loaded Game Mode: " + gameMode);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}