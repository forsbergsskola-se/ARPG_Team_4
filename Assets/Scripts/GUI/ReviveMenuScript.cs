using Units.Player;
using UnityEngine;

public class ReviveMenuScript : MonoBehaviour {
    public HealthScriptableObject healthScriptableObject; 
    [SerializeField] private GameObject menuRef;
    private PlayerReviveHandler _playerReviveHandler => GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerReviveHandler>();
    public GameObject shadow;
    
    void Start() {
        // Register for player death event
        healthScriptableObject.OnDeath += ShowMenu;
    }

    private void OnDestroy() {
        healthScriptableObject.OnDeath -= ShowMenu;
    }

    public void ReviveButton() {
        //Debug.Log("Revive button clicked");
        _playerReviveHandler.ReviveAtLocation();
        PlayButtonSound(true);
        PlayReviveSound(true);
        HideMenu();
    }
    
    public void LoadCheckpointButton() {
        //Debug.Log("Resurrect button clicked");
        _playerReviveHandler.ReviveAtCheckpoint();
        PlayButtonSound(true);
        PlayReviveSound(true);
        HideMenu();
    }

    public void MenuButton() {
        Debug.Log("Quit to main menu clicked");
        PlayButtonSound(true);
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
    
    private void PlayButtonSound(bool setReviveSFX) {
        var AT = FindObjectOfType<Audio_Character_Controller>();
        AT.ReviveSFXSet(setReviveSFX);
    }
    private void PlayReviveSound(bool setButton_1_SFX)
    {
        var AT = FindObjectOfType<Audio_SFX_Controller>();
        AT.Button_1_SFXSet(setButton_1_SFX);
    }
}
        /*
        var aTposition = AT.gameObject.transform.position;
        FMODUnity.RuntimeManager.PlayOneShot("event:/THESPLIT/CharacterSplit/ReviveSplit/ReviveSplit", aTposition);
        string BusString = "Bus:/";
        FMOD.Studio.Bus masterBus;
        masterBus = FMODUnity.RuntimeManager.GetBus("event:/SFX/Button/Buttons");
        */