using UnityEngine;

namespace util {
	public class LevelManager : MonoBehaviour {

		public RoomObjectManager roomObjectManager;
		public float time;
		public TimeKeeper timeKeeper;
		public float backgroundMusicVolume;
		public AudioClip backgroundMusic;
		public float levelEndMusicVolume;
		public AudioClip levelEndMusic;
		
		void Start () {
			timeKeeper.countdownTime = time;
			if (backgroundMusic != null) {
				AudioManager.instance.musicSource.volume = backgroundMusicVolume;
				AudioManager.instance.PlayMusic (backgroundMusic);
			}
		}
		
		public void EndLevel () {
			AudioManager.instance.musicSource.volume = levelEndMusicVolume;
			AudioManager.instance.PlayMusic (levelEndMusic);
		}
	}
}
