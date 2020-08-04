using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class Sign : MonoBehaviour
{
    public string[] _actors;
    private MeshRenderer _text;
    private List<GameObject> _colliders;

    public void Awake()
    {
        _colliders = new List<GameObject>();
        _text = GetComponentsInChildren<MeshRenderer>().First();
    }

    public void Start()
    {
        _text.enabled = false;
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
            _text.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _colliders.Remove(other.gameObject);

        if (!_colliders.Contains(other.gameObject))
        {
            if (_actors.Contains(other.gameObject.tag))
            {
                _text.enabled = false;
            }
        }
    }
}
