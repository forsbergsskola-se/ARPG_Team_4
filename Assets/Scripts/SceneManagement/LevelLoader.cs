using System;
using System.Collections;
using Units.Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class LevelLoader : MonoBehaviour {
        public float transitionTime = 1f;
        public Animator animator;
        
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<NavMeshAgent>().enabled = false;
                other.GetComponent<ClickToMove>().enabled = false;
                LoadNextLevel();
            }
        }

        private void LoadNextLevel() {
            //ScreenCapture.CaptureScreenshot("loadScreenShot");
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        IEnumerator LoadLevel(int levelIndex) {
            animator.SetTrigger("ExitScene");
            
            yield return new WaitForSeconds(transitionTime);
            
            SceneManager.LoadScene(levelIndex);
        }
    }
}
