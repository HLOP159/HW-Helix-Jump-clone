using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Platform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }    
        }

        public static implicit operator Platform(ScoreText v)
        {
            throw new NotImplementedException();
        }
    }
}