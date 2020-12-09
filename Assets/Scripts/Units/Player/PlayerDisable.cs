using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units.Player;

[RequireComponent(typeof(ClickToMove))]
public class PlayerDisable : MonoBehaviour
{
    /*
     * Make so that is check for Menu Open (layer/categorie), Loading and other stuff when need to be still and then switch "if Yes" to make Disable to be On.
     * 
     * if var I = 0; I =1 turn on the Disable
     * If var I = 2 turn off Disable and Reset var I to 0
     */
    public KeyCode MenuButton; //Bind to the same button as the Menu
    private ClickToMove _disableClickToMove = null;
    private int I = 0;
    void Start()
    {
        _disableClickToMove = GetComponent<ClickToMove>();
    }
    void Update()
    {
        if (Input.GetKeyDown(MenuButton))
        {
            Debug.Log("Menu Button Pressed On " + I);
            I++;
        }
        else if (I == 1)
        {
            OnDisable();
        }
        else if (I == 2)
        {
            I -= 2;
            Debug.Log("Menu Button Pressed Off " + I);
            OnEnable();
        }
    }

    void OnDisable()
    {
        Debug.Log("OnDisable is On " + I);
        _disableClickToMove.InputDisabled = true;
    }
    void OnEnable()
    {
        Debug.Log("OnDisable is Off " + I);
        _disableClickToMove.InputDisabled = false;
    }
}


