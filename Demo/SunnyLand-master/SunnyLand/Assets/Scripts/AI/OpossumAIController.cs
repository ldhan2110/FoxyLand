using SunnyLand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class OpossumAIController : MonoBehaviour
{
    private PlatformerCharacter2D _character;
    private float _speed = 0.2f;

    private void Awake()
    {
        _character = GetComponent<PlatformerCharacter2D>();
    }

    private void FixedUpdate ()
    {
        if (!_character.IsGrounded || _character.IsFrontBlocked)
        {
            _character.Flip();
            _speed *= -1f;
        }
        else
        {
            _character.Move(_speed, false, false);
        }
    }
}
