using UnityEngine;

public class BoyWinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Boy>(out Boy boy))
            boy.Dance();
    }
}