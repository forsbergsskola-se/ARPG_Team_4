using System.Collections;
using Units.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement {
    public class LevelLoader : MonoBehaviour {
        public Animator animator;
        public float transitionTime = 2f;
        private const string animPlayAnimation = "PlayAnimation";
        private const string animSceneLoaded = "SceneLoaded";

        private void Awake() {
            animator.SetTrigger(animPlayAnimation);
            animator.SetBool(animSceneLoaded, false);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<PlayerMovement>().InputDisabled = true;
                LoadNextLevel();
            }
        }

        private void LoadNextLevel() {
            animator.SetTrigger(animPlayAnimation);
            animator.SetBool(animSceneLoaded, true);

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        
        private IEnumerator LoadLevel(int levelIndex) {
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