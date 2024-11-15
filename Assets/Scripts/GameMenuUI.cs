using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MyVrSample
{
    public class GameMenuUI : MonoBehaviour
    {
        #region Variables
        public GameObject gameMenuUI;
        public InputActionProperty showGameMenu;
        #endregion

        private void Update()
        {
            if (showGameMenu.action.WasPressedThisFrame())      //이번프레임에 눌렀냐
            {
                Toggle();
            }
        }
        void Toggle()
        {
            gameMenuUI.SetActive(!gameMenuUI.activeSelf);
        }
    }
}
