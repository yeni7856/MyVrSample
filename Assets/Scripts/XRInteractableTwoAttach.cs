using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// �ΰ��� Attach Point ����
    /// </summary>
    public class XRInteractableTwoAttach : XRGrabInteractable
    {
        #region Variables
        public Transform leftAttachTransform;
        public Transform rightAttachTransform;
        #endregion
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            //�ΰ��� Attach Point�� ��� �տ� ���� �����ؼ� ����
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }

            base.OnSelectEntered(args);
        }
    }
}
