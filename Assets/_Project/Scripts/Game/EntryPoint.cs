using TMPro;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private BoySpawner _boySpawner;
    [SerializeField] private ButtonTrigger _buttonTrigger;
    [SerializeField] private TMP_Text _scoreText;

    private GameStats _gameStats;
    private SaveSystem _saveSystem;
    private ScoreChanger _scoreChanger;

    private void Start()
    {
        _gameStats = new();
        _saveSystem = new(_gameStats);

        _saveSystem.Load();

        _scoreChanger = new(_gameStats, _saveSystem, _scoreText);
        _boySpawner.Initialization(_scoreChanger);
        _buttonTrigger.Initialization(_boySpawner);
    }
}