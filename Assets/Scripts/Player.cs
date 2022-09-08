using Assets.Scripts;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;

    public Platform CurrentPlatform;

    private void Start()
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void Die()
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        particleSystem.Play();
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }
}
