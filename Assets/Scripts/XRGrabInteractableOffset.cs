using UnityEditor.XR.Interaction.Toolkit.Interactors;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVrSample
{
    /// <summary>
    /// ������Ʈ�� ������ �ɼ� ��ġ ����
    /// </summary>
    public class XRGrabInteractableOffset : XRGrabInteractable
    {
        #region Variables
        private GameObject attachPoint;
        private Vector3 initialLocalPosition;
        private Quaternion initialLocalRotation;
        #endregion

        private void Start()
        {
            //attachPoint ������Ʈ �����
            if (attachPoint == null)
            {
                attachPoint = new GameObject("Offset Grab Pivot");
                attachPoint.transform.SetParent(transform, false);  //������Ʈ �ڽ�����
                attachTransform = attachPoint.transform;
            }
            else
            {
                initialLocalPosition = attachPoint.transform.localPosition; 
                initialLocalRotation = attachTransform.localRotation;
            }
        }

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            if (args.interactorObject is XRDirectInteractor)
            {
                attachTransform.position = args.interactorObject.transform.position;
                attachTransform.rotation = args.interactorObject.transform.rotation;
            }
            else
            {
                attachTransform.localPosition = initialLocalPosition;
                attachTransform.localRotation = initialLocalRotation;
            }

            base.OnSelectEntering(args);
        }
        /*        protected override void OnSelectEntered(SelectEnterEventArgs args)
                {
                    if(args.interactorObject is XRDirectInteractor)
                    {
                        attachTransform.position = args.interactorObject.transform.position;
                        attachTransform.rotation = args.interactorObject.transform.rotation;
                    }
                    else
                    {
                        attachTransform.localPosition = initialLocalPosition;
                        attachTransform.localRotation = initialLocalRotation;
                    }

                    base.OnSelectEntered(args);
                }*/
    }
}