using System.Collections;
using GUI;
using Units.Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class LevelLoader : MonoBehaviour {
        public Animator animator;
        public float transitionTime = 1f;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<NavMeshAgent>().enabled = false;
                other.GetComponent<PlayerMovement>().enabled = false;
                LoadNextLevel();
            }
        }

        private void LoadNextLevel() {
            var menuScript = GameObject.Find("/Canvas_UI").GetComponent<MenuScript>();
            
            // Disable menu during transition
            if (menuScript == null) {
                Debug.Log("MenuScript not found in /Canvas_UI", this);
            }
            else
                menuScript.enabled = false;

            //load next level
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        
        private IEnumerator LoadLevel(int levelIndex) {
            
            animator.SetTrigger("ExitScene");
            
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