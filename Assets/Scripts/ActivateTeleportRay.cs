using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray �� �����ϴ� Ŭ���� 
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;                      //�ڷ���Ʈ ���� Ray ������Ʈ
        public GameObject rightTeleportRay;                   //�ڷ���Ʈ ������ Ray ������Ʈ

        public InputActionProperty leftActivate;                //���� ��Ʈ�ѷ��� activate �Է�
        public InputActionProperty rightActivate;             //������ ��Ʈ�ѷ��� activate �Է�

        public XRRayInteractor leftGrapLay;                     //���� �׷�����   (���̰� ���̸� �ڷ���Ʈ ��Ȱ��ȭ)
        public XRRayInteractor rightGrapLay;                  //������ �׷�����

        #endregion

        private void Update()
        {
            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightAcivateValue = rightActivate.action.ReadValue<float>();

            //��Ʈ���� �������� 
            //��ȿ�ϸ� Ʈ���޽� ��ȯ������
            bool isLeftRayHovering = leftGrapLay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal,
                out int leftNumber, out bool leftValid);        

            bool isRightRayHovering = rightGrapLay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal,
                out int rightNumber, out bool rightValid);

            //isLeftRayHovering, isRightRayHovering(ȣ������ ������ Ȱ��ȭ) 
            leftTeleportRay.SetActive(!isLeftRayHovering && leftActivateValue > 0.1f);            //0.1�̻� ������ Ȱ��
            rightTeleportRay.SetActive(!isRightRayHovering && rightAcivateValue > 0.1f);
        }
    }
}
