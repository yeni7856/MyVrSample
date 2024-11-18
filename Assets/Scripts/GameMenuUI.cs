using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

namespace MyVrSample
{
    /// <summary>
    /// ������ �޴� UI �����ϴ� Ŭ����
    /// </summary>
    public class GameMenuUI : MonoBehaviour
    {
        #region Variables
        public GameObject gameMenuUI;
        public InputActionProperty showGameMenu;

        public Transform head;
        [SerializeField] private float distance = 1.5f;

        //Drop UI
        public SnapTurnProvider snapTurn;
        public ContinuousTurnProvider continuousTurn;
        #endregion

        private void Update()
        {
            if (showGameMenu.action.WasPressedThisFrame())      //�̹������ӿ� ������
            {
                Toggle();
            }
        }
        void Toggle()
        {
            gameMenuUI.SetActive(!gameMenuUI.activeSelf);

            //show ����
            if (gameMenuUI.activeSelf)
            {
                gameMenuUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
                gameMenuUI.transform.LookAt(new Vector3(head.position.x, gameMenuUI.transform.position.y, head.position.z));
                gameMenuUI.transform.forward *= -1;
            }

        }

        //drop �޴� ����
        public void SetTurnTypeFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    snapTurn.enabled = false;
                    continuousTurn.enabled = true;
                    break;
                case 1:
                    snapTurn.enabled = true;
                    continuousTurn.enabled = false;
                    break;
            }
        }

        //Quit ��ư
        public void Quit()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}
