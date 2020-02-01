using System;
using UnityEngine;

namespace util {
    public class Timer : MonoBehaviour {
    
        private bool isRunning;
        [SerializeField] private float timeCounter;
        public float time;

        void Update () {
            if (isRunning) {
                timeCounter += Time.deltaTime;
                if (timeCounter >= time) {
                    timeCounter = time;
                    isRunning = false;
                }
            }
        }

        public void Run () {
            isRunning = true;
        }

        public void Pause () {
            isRunning = false;
        }

        public void Rewind () {
            isRunning = false;
            timeCounter = 0f;
        }

        public void Restart () {
            timeCounter = 0f;
        }

        public bool IsRunning () {
            return isRunning;
        }

        public bool IsDone () {
            return timeCounter >= time;
        }
    }
}