using System;
using UnityEngine;

namespace util {
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;
        public static int currentLevel = 0;
        public int onLevel;
        
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            DontDestroyOnLoad (gameObject);
        }

        private void Update () {
            onLevel = currentLevel;
        }

    }
}
