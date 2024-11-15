using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


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

        public XRRayInteractor leftGrapLay;                     //왼쪽 그랩레이   (레이가 보이면 텔레포트 비활성화)
        public XRRayInteractor rightGrapLay;                  //오른쪽 그랩레이

        #endregion

        private void Update()
        {
            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightAcivateValue = rightActivate.action.ReadValue<float>();

            //히트정보 가져오기 
            //유효하면 트루펄스 반환시켜줌
            bool isLeftRayHovering = leftGrapLay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal,
                out int leftNumber, out bool leftValid);        

            bool isRightRayHovering = rightGrapLay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal,
                out int rightNumber, out bool rightValid);

            //isLeftRayHovering, isRightRayHovering(호버하지 않으면 활성화) 
            leftTeleportRay.SetActive(!isLeftRayHovering && leftActivateValue > 0.1f);            //0.1이상 레이저 활성
            rightTeleportRay.SetActive(!isRightRayHovering && rightAcivateValue > 0.1f);
        }
    }
}
