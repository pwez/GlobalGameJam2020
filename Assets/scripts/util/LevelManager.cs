using System;
using System.Collections;
using input;
using players;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace util {
	public class LevelManager : MonoBehaviour {

		public int levelNumber;
		public float minPercentageNeeded;
		
		public float time;
		public TimeKeeper timeKeeper;
		
		public float backgroundMusicVolume;
		public AudioClip backgroundMusic;
		public AudioClip levelEndSFX;
		public float levelEndMusicVolume;
		public AudioClip levelEndMusic;

		public Animator sceneTransition;

		private PlayerInput[] playerInputs;
		
		private void Awake () {
			timeKeeper.countdownTime = time;
			playerInputs = FindObjectsOfType<PlayerInput> ();
		}

		void Start () {
			GameManager.currentLevel = levelNumber;
			if (backgroundMusic != null) {
				AudioManager.instance.musicSource.volume = backgroundMusicVolume;
				AudioManager.instance.PlayMusic (backgroundMusic);
			}
		}
		
		public void EndLevel () {
			foreach (var playerInput in playerInputs) {
				playerInput.enabled = false;
			}
			AudioManager.instance.musicSource.Stop ();
			AudioManager.instance.PlaySound (levelEndSFX);
			StartCoroutine (TransitionScenes ());
		}

		IEnumerator TransitionScenes () {
			sceneTransition.SetBool ("FadeOut", true);
			yield return new WaitForSeconds (3f);
			AudioManager.instance.musicSource.volume = levelEndMusicVolume;
			AudioManager.instance.PlayMusic (levelEndMusic);
			if (minPercentageNeeded >= RoomObjectManager.instance.GetPercentageRepaired ()) {
				SceneManager.LoadSceneAsync("Success");
				sceneTransition.SetBool ("FadeIn", true);
			}
			else {
				SceneManager.LoadSceneAsync ("Failure");
			}
			sceneTransition.SetBool ("FadeOut", false);
		}

	}
}
