using System;
using System.Collections;
using GUI;
using Units.Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace SceneManagement {
    public class LevelLoader : MonoBehaviour {
        public Animator animator;
        public float transitionTime = 2f;
        public bool PlayAnimation = false;
        public bool SceneLoaded = false;
        private const string animPlayAnimation = "PlayAnimation";
        private const string animSceneLoaded = "SceneLoaded";

        private void Awake() {
            animator.SetTrigger(animPlayAnimation);
            animator.SetBool(animSceneLoaded, SceneLoaded = false);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<NavMeshAgent>().enabled = false;
                other.GetComponent<PlayerMovement>().enabled = false;
                LoadNextLevel();
            }
        }

        private void LoadNextLevel() {
            var menuScript = GameObject.Find("/Canvas_PauseMenu_UI").GetComponent<Canvas>();

            menuScript.enabled = false;
            animator.SetTrigger(animPlayAnimation);
            animator.SetBool(animSceneLoaded, SceneLoaded = true);

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        
        private IEnumerator LoadLevel(int levelIndex) {
            
            // animator.SetTrigger("ExitScene");
            
            yield return new WaitForSeconds(transitionTime);
            
            SceneManager.LoadScene(levelIndex);
        }
    }
}

/*
 * Davids Async solution (needs fix to wait for animation before loading)
 *
private IEnumerator LoadLevelAsync(int levelIndex)
        {
            // The Application loads the Scene in the background as the current Scene runs.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);
            
            // Play animation
            animator.SetTrigger("ExitScene");
            
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
*/