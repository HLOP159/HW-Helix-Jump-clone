using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}