using UnityEngine;

public abstract class TriggerHandler : MonoBehaviour
{
    public abstract void Handle(TriggerEventArgs args);
}
