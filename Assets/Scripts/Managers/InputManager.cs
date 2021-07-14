using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : Singleton<InputManager>
{ 
    public float horizontalInput;
    public float verticalInput;

    private bool _isItemTriggered;

    private void Awake()
    {
        Subscribe();
    }

    private void Update()
    {
       
        if (_isItemTriggered && Input.GetKeyUp(KeyCode.E))
        {
            GlobalEventManager.instance.TakeButtonPressedEvent.Invoke();
        }
    }

    private void Subscribe()
    {
        GlobalEventManager.instance.ItemTriggeredEvent += CheckIsItemTriggered;
    }

    public (float, float) GetMoveInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return (horizontalInput, verticalInput);
    }

    private void CheckIsItemTriggered(bool isTriggered)
    {
        _isItemTriggered = isTriggered;
    }
}
