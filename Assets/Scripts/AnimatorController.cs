using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    public class AnimatorController : MonoBehaviour
    {
        #region Variables
        private Animator handAnimatior;

        //ÀÎÇ²°ªÃ³¸®
        public InputActionProperty pinchAnimationAction;
        public InputActionProperty gripAnimationAction;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            handAnimatior = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            float triggerValue =  pinchAnimationAction.action.ReadValue<float>();
            float gripValue = gripAnimationAction.action.ReadValue<float>();

            handAnimatior.SetFloat("Trigger", triggerValue);
            handAnimatior.SetFloat("Grip", gripValue);

        }
    }
}
