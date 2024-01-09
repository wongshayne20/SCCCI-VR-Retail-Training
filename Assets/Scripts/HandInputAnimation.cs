using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInputAnimation : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float TriggerValue = pinchAnimationAction.action.ReadValue<float>();
        float GripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", TriggerValue);
        handAnimator.SetFloat("Grip", GripValue);

    }
        
}
