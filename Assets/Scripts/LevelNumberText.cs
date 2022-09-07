using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelNumberText : MonoBehaviour
    {
        public Text CurrentLevel;
        public Game Game;

        private void Start()
        {
            CurrentLevel.text = (Game.LevelIndex + 1).ToString();
        }
    }
}