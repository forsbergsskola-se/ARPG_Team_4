using UnityEngine;

/// <summary>
/// Makes menu appear and disappear when button is clicked.
/// Handles Button Actions
/// </summary>

// TODO mousover vfx, button press vfx,
// TODO menu transition vfx, 
// TODO Button sound effect

public class MenuScript : MonoBehaviour
{
    public GameObject menuRef;
    private readonly string menuString = "Menu";
    public AudioSource buttonSound;
    
    void Update() {

        if (Input.GetButtonDown(menuString)) {
            bool theMenuIsActive = menuRef.activeSelf;
            if (theMenuIsActive) {
                menuRef.SetActive(false);
                ResumeGame();
            }
            else {
                PauseGame();
                menuRef.SetActive(true);
            }
        }
    }

    public void ResumeButton() {
        PlayButtonSound();
        menuRef.SetActive(false);
        ResumeGame();
    }

    public void LoadCheckpointButton() {
        //TODO
        buttonSound.Play();
        Debug.Log("Load cehckpoint clicked");
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
        Application.Quit();
    }

    private void PlayButtonSound() {
        buttonSound.Play();
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
