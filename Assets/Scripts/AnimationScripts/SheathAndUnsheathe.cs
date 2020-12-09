using UnityEngine;

public class SheathAndUnsheathe : MonoBehaviour {
    public GameObject[] ItemHand;
    public GameObject[] ItemHolster;

    public void Sheathe(int itemIndex) {
        ItemHand[itemIndex].SetActive(false);
        ItemHolster[itemIndex].SetActive(true);
    }
    public void UnSheathe(int itemIndex) {
        ItemHand[itemIndex].SetActive(true);
        ItemHolster[itemIndex].SetActive(false);
    }
}
