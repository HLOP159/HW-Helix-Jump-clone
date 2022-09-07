using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip BreakPlatformSound;

    private AudioSource _bounceSound;

    void Start()
    {
        _bounceSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _bounceSound.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        _bounceSound.PlayOneShot(BreakPlatformSound);
    }
}
