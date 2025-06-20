using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSys : MonoBehaviour
{
    public InputActionReference gripInputActionReference;
    public InputActionReference triggerInputActionReference;

    private float _gripValue;
    private float _triggerValue;

    private void Start()
    {
        
    }

    private void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = gripInputActionReference.action.ReadValue<float>();
        Debug.Log(_gripValue);
    }

    private void AnimateTrigger()
    {
        _triggerValue = triggerInputActionReference.action.ReadValue<float>();
        Debug.Log( _triggerValue);
    }
}
