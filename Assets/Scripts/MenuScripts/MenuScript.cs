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
            menuRef.SetActive(!theMenuIsActive);
        }
    }

    public void ResumeButton() {
        PlayButtonSound();
        menuRef.SetActive(false);
    }

    public void QuitButton() {
        Debug.Log("The application should quit if the game is built");
        PlayButtonSound();
        Application.Quit();
    }

    private void PlayButtonSound() {
        buttonSound.Play();
    }
}
