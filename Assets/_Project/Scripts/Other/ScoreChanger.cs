using TMPro;

public class ScoreChanger
{
    private GameStats _gameStats;
    private SaveSystem _saveSystem;
    private TMP_Text _scoreText;
 
    public ScoreChanger(GameStats gameStats, SaveSystem saveSystem, TMP_Text scoreText)
    {
        _gameStats = gameStats;
        _saveSystem = saveSystem;
        _scoreText = scoreText;

        _scoreText.text = _gameStats.Score.ToString();
    }

    public void ChangeScore(int value)
    {
        if (value <= 0)
            return;

        _gameStats.Score += value;
        _scoreText.text = _gameStats.Score.ToString();
        _saveSystem.Save();
    }
}