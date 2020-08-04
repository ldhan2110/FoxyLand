using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CrankState
{
    Up,
    Down
}

[RequireComponent(typeof(SpriteRenderer))]
public class Crank : MonoBehaviour
{
    public string[] _actors;
    public CrankState _state;
    public Sprite _upSprite;
    public Sprite _downSprite;

    private SpriteRenderer _renderer;
    private List<GameObject> _colliders;

    public void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _colliders = new List<GameObject>();
    }

    public void Start()
    {
        UpdateSprite();
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
            RevertState();
            UpdateSprite();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _colliders.Remove(other.gameObject);
    }

    private void RevertState()
    {       
        switch (_state)
        {
            case CrankState.Up:
                _state = CrankState.Down;
                break;

            case CrankState.Down:
                _state = CrankState.Up;
                break;
        }
    }

    private void UpdateSprite()
    {
        switch (_state)
        {
            case CrankState.Up:
                _renderer.sprite = _upSprite;
                break;

            case CrankState.Down:
                _renderer.sprite = _downSprite;
                break;
        }
    }
}
