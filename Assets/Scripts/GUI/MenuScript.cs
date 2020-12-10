using Units.Player;
using UnityEngine;

namespace GUI {
    /// <summary>
    /// Makes menu appear and disappear when button is clicked.
    /// Handles PortalButton Actions
    /// </summary>

// TODO mousover vfx, button press vfx,
// TODO menu transition vfx, 
// TODO PortalButton sound effect

    public class MenuScript : MonoBehaviour
    {
        public GameObject menuRef;
        private readonly string menuString = "Menu";
        public AudioSource buttonSound;
        public GameObject shadow;
        private ClickToMove clickToMove;

        private void Start() {
            clickToMove = GameObject.FindGameObjectWithTag("Player").GetComponent<ClickToMove>();
            if (clickToMove == null)
                Debug.LogWarning("ClickToMove missing", this);
        }

        void Update() {

            if (Input.GetButtonDown(menuString)) {
                bool theMenuIsActive = menuRef.activeSelf;
                if (theMenuIsActive) {
                    menuRef.SetActive(false);
                    shadow.SetActive(false);
                    clickToMove.InputDisabled = false;
                    ResumeGame();
                }
                else {
                    PauseGame();
                    menuRef.SetActive(true);
                    shadow.SetActive(true);
                    clickToMove.InputDisabled = true;
                }
            }
        }

        public void ResumeButton() {
            PlayButtonSound();
            shadow.SetActive(false);
            menuRef.SetActive(false);
            clickToMove.InputDisabled = false;
            ResumeGame();
        }

        public void LoadCheckpointButton() {
            //TODO
            buttonSound.Play();
            Debug.Log("Load checkpoint clicked");
        }
    
        public void SettingsButton() {
            //TODO
            buttonSound.Play();
            Debug.Log("Settings clicked");
        }
    
        public void QuitToMainMenuButton() {
            //TODO
            buttonSound.Play();
            Debug.Log("Quit to main menu clicked");
        }
    

        public void QuitButton() {
            Debug.Log("The application should quit if the game is built");
            PlayButtonSound();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    
        private void PlayButtonSound() {
            //            buttonSound.Play();
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Button/Buttons");
        }
    
        void PauseGame ()
        {
            Time.timeScale = 0f;
        }

        void ResumeGame ()
        {
            Time.timeScale = 1;
        }
    }
}
