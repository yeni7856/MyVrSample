using UnityEngine;
using UnityEngine.InputSystem;


namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray 를 관리하는 클래스 
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;                      //텔레포트 왼쪽 Ray 오브젝트
        public GameObject rightTeleportRay;                   //텔레포트 오른쪽 Ray 오브젝트

        public InputActionProperty leftActivate;                //왼쪽 컨트롤러의 activate 입력
        public InputActionProperty rightActivate;             //오른쪽 컨트롤러의 activate 입력

        #endregion

        private void Update()
        {
            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightAcivateValue = rightActivate.action.ReadValue<float>();

            leftTeleportRay.SetActive(leftActivateValue > 0.1f);            //0.1이상 레이저 활성
            rightTeleportRay.SetActive(rightAcivateValue > 0.1f);
        }
    }
}
