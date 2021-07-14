using UnityEngine;

public class Coin : Item
{
    protected override void TakeButtonPressed()
    {
        GlobalEventManager.instance.ItemTriggeredEvent.Invoke(false);
        if (_isTriggered)
        {
            PlayPickUpSound();
            _isTriggered = false;
            GlobalEventManager.instance.CoinChangedEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
