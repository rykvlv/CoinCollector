using UnityEngine;
using System;

public class GlobalEventManager : Singleton<GlobalEventManager>
{
    public Action CoinChangedEvent;
    public Action ExperienceChangedEvent;
    public Action GameOverEvent;
    public Action<bool> ItemTriggeredEvent;
    public Action TakeButtonPressedEvent;
}
