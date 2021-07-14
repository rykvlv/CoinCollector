using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float rotateSpeed = 1.0f;
    [SerializeField] protected AudioClip collectedSound;

    protected bool _isTriggered;

    protected void Awake()
    {
        Subscribe();
    }

    protected void Update()
    {
        Rotate();
    }

    protected void Subscribe()
    {
        GlobalEventManager.instance.TakeButtonPressedEvent += TakeButtonPressed;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalEventManager.instance.ItemTriggeredEvent.Invoke(true);
            _isTriggered = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalEventManager.instance.ItemTriggeredEvent.Invoke(false);
            _isTriggered = false;
        }
    }

    protected abstract void TakeButtonPressed();

    protected void Rotate()
    {
        this.transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    protected void PlayPickUpSound()
    {
        if (collectedSound != null)
        {
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
        }
    }
}
