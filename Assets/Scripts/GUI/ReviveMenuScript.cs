using Units.Player;
using UnityEngine;

public class ReviveMenuScript : MonoBehaviour {
    public HealthScriptableObject healthScriptableObject; 
    public GameObject menuRef;
    private PlayerReviveHandler _playerReviveHandler;
    public GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {
        // Register for player death event
        healthScriptableObject.OnDeath += ShowMenu;
        
        //get reference to revive handler
        _playerReviveHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerReviveHandler>();
        if (_playerReviveHandler == null)
            Debug.LogWarning("Couldn't find revive handler on Player OR player couldn't be found", this);
    }
    
    public void ReviveButton() {
        Debug.Log("Revive button clicked");
        _playerReviveHandler.ReviveAtLocation();
        PlayButtonSound();
        HideMenu();
    }
    
    public void LoadCheckpointButton() {
        Debug.Log("Resurrect button clicked");
        _playerReviveHandler.ReviveAtCheckpoint();
        PlayButtonSound();
        HideMenu();
    }

    public void MenuButton() {
        Debug.Log("Quit to main menu clicked");
        PlayButtonSound();
        HideMenu();
    }
    
    private void ShowMenu() {
        menuRef.SetActive(true);
        shadow.SetActive(true);
    }

    private void HideMenu() {
        menuRef.SetActive(false);
        shadow.SetActive(false);
    }
    
    private void PlayButtonSound() {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Button/Buttons");
    }
}