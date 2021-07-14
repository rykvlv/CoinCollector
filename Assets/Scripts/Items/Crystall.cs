using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystall : Item
{
    protected override void TakeButtonPressed()
    {
        GlobalEventManager.instance.ItemTriggeredEvent.Invoke(false);
        if (_isTriggered)
        {
            PlayPickUpSound();
            _isTriggered = false;
            GlobalEventManager.instance.ExperienceChangedEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
