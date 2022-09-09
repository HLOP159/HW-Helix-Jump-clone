using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    void Start()
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        particleSystem.Play();
    }
}
