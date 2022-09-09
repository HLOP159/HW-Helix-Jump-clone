using UnityEngine;

public class Finish : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>(); // ��������� ������� ������ ������
        particleSystem.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        player.ReachFinish();
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>(); // �������� ������� ������ ������
        particleSystem.Play();
    }
}
