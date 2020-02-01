using UnityEngine;

namespace util {
    public class AudioManager : MonoBehaviour {

        public AudioSource sfxSource;
        public AudioSource musicSource;
        public static AudioManager instance = null;              
        
        private AudioManager () {}

        void Awake () {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            DontDestroyOnLoad (gameObject);
        }

        public void PlaySound (AudioClip clip) {
            sfxSource.clip = clip;
            sfxSource.Play ();
        }
        
        public void PlayMusic (AudioClip clip) {
            musicSource.clip = clip;
            musicSource.Play ();
        }
    }
}
