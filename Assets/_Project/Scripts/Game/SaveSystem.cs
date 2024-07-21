using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    private GameStats _gameStats;

    private const string GAME_STATS = "GameStats";

    public SaveSystem(GameStats gameStats)
    {
        _gameStats = gameStats;
    }

    public void Save()
    {
        var savedData = JsonUtility.ToJson(_gameStats);
        PlayerPrefs.SetString(GAME_STATS, savedData);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        var loadedData = JsonUtility.FromJson<GameStats>(PlayerPrefs.GetString(GAME_STATS));

        if (loadedData != null)
            _gameStats.Score = loadedData.Score;
    }
}