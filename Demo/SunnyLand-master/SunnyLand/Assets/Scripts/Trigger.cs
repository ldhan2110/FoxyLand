using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventArgs
{
    public TriggerEventArgs(GameObject trigger, GameObject other)
    {
        Trigger = trigger;
        Other = other;
    }

    public GameObject Trigger { get; private set; }

    public GameObject Other { get; private set; }
}

[Serializable]
public class TriggerEvent : UnityEvent<TriggerEventArgs>
{
}

[RequireComponent(typeof(Collider2D))]
public sealed class Trigger : MonoBehaviour
{
    public string[] _actors;
    public TriggerEvent TriggerEvent;

    private List<GameObject> _colliders;

    public void Awake()
    {
        _colliders = new List<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_colliders.Contains(other.gameObject))
        {
            _colliders.Add(other.gameObject);
            return;
        }

        _colliders.Add(other.gameObject);

        if (_actors.Contains(other.gameObject.tag))
        {
            TriggerEvent.Invoke(new TriggerEventArgs(gameObject, other.gameObject));
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _colliders.Remove(other.gameObject);
    }
}
