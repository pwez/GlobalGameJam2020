using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using util;

public class Cutscene : MonoBehaviour {

    public Animator sceneTransition;
    public float duration;
    [SerializeField]private float counter;
    public bool canProceed;
    
    // Start is called before the first frame update
    void Start() {
        sceneTransition.SetBool ("FadeIn", true);
        counter = duration;
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
        AudioManager.instance.musicSource.Stop ();
        sceneTransition.SetBool ("FadeIn", false);
        sceneTransition.SetBool ("FadeOut", true);
        yield return new WaitForSeconds (3f);
        SceneManager.LoadSceneAsync ("Level_" + GameManager.currentLevel++);
    }
}
