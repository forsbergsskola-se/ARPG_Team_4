using System;
using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    public class HighlightWeaponImages : MonoBehaviour {

        //private FSMWorkWithAnimation _fsmWorkWithAnimation;
        [SerializeField] private Image crowbarHighlightImage;
        [SerializeField] private Image crowbarImage;
        [SerializeField] private Image handgunHighlightImage;
        [SerializeField] private Image handgunImage;

        private FSMWorkWithAnimation FSMWorkWithAnimation => FindObjectOfType<FSMWorkWithAnimation>();

        private void Start() {
            UpdateImages();
            FSMWorkWithAnimation.OnWeaponSwitch += UpdateImages;
        }

        private void OnDestroy() {
            if (FSMWorkWithAnimation != null)
                FSMWorkWithAnimation.OnWeaponSwitch -= UpdateImages;
        }

        private void UpdateImages() {
            crowbarHighlightImage.enabled = FSMWorkWithAnimation.CrowbarIsReady;
            crowbarImage.enabled = !FSMWorkWithAnimation.CrowbarIsReady;
            handgunHighlightImage.enabled = FSMWorkWithAnimation.GunIsReady;
            handgunImage.enabled = !FSMWorkWithAnimation.GunIsReady;
        }
    }
}
