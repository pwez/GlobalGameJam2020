using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using util;

public class Cutscene : MonoBehaviour {

    public bool shouldStopMusicDuringTransition;
    public int sceneIndexToGoTo;
    public Animator sceneTransition;
    public float duration;
    [SerializeField]private float counter;
    public bool canProceed;
    public AudioClip soundToPlay;
    
    // Start is called before the first frame update
    void Start() {
        sceneTransition.SetBool ("FadeIn", true);
        counter = duration;
        if (soundToPlay != null) {
            AudioManager.instance.PlaySound (soundToPlay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0) {
            counter -= Time.deltaTime;
            if (counter <= 0) {
                canProceed = true;
            }
        }

        if (canProceed) {
            if (Input.GetKeyDown (KeyCode.Return)) {
                StartCoroutine (TransitionScenes ());
            }
        }
        
    }
    
    IEnumerator TransitionScenes () {
        if (shouldStopMusicDuringTransition) {
            AudioManager.instance.musicSource.Stop ();
            AudioManager.instance.sfxSource.Stop ();
        }
        sceneTransition.SetBool ("FadeIn", false);
        sceneTransition.SetBool ("FadeOut", true);
        yield return new WaitForSeconds (3f);
        SceneManager.LoadSceneAsync (sceneIndexToGoTo);
    }
}
