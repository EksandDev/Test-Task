using System.Collections;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MeshRenderer _buttonMesh;
    [SerializeField] private int _secondsToSpawn = 3;

    private BoySpawner _spawner;

    public void Initialization(BoySpawner spawner)
    {
        _spawner = spawner;
        _buttonMesh.material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            _buttonMesh.material.color = Color.green;
            StartCoroutine(SpawnBoy());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            _buttonMesh.material.color = Color.red;
            StopAllCoroutines();
        }
    }

    private IEnumerator SpawnBoy()
    {
        yield return new WaitForSeconds(_secondsToSpawn);

        _spawner.Spawn(_spawnPoint.position, Quaternion.identity);
        _buttonMesh.material.color = Color.red;
    }
}