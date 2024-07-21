using UnityEngine;

public class BoyRotator : MonoBehaviour
{
    [SerializeField] private Boy _boy;
    [SerializeField] private float _rotationSpeed = 10;

    private Transform _target => _boy?.Target;

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp
            (transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }

}