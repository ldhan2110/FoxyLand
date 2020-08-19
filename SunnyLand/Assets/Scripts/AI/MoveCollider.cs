using SunnyLand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider : MonoBehaviour
{
    private MovePlatform _character;
    private float _speed = 0.2f;

    private void Awake()
    {
        _character = GetComponent<MovePlatform>();
    }

    private void FixedUpdate ()
    {
        if (_character.IsFrontBlockedByTile)
        {
            _speed *= -1f;
            _character.Flip();
        }
        else
        {
            _character.Move(_speed);
        }
    }
}
