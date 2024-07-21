using UnityEngine;

public class BoySpawner : MonoBehaviour
{
    [SerializeField] private Boy _prefab;
    [SerializeField] private Transform _boyTarget;

    private ScoreChanger _scoreChanger;

    public void Initialization(ScoreChanger scoreChanger)
    {
        _scoreChanger = scoreChanger;
    }

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        var newBoy = Instantiate(_prefab, position, rotation);
        newBoy.Initialization(_scoreChanger, _boyTarget);
    }
}
