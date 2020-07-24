using SunnyLand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Enemy : MonoBehaviour
{
    private PlatformerCharacter2D _character;
    private Rigidbody2D m_Rigidbody2D;
    private float _speed = 0.1f;
    [SerializeField] private float m_IdleTime = 2.5f;
    private int jumpTimes=0;


    private void Awake()
    {
        _character = GetComponent<PlatformerCharacter2D>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (_character.IsGrounded)
        {
            m_IdleTime -= Time.deltaTime;
            _character.Move(0, false, false);
        }

        if (m_IdleTime <= 0)
        {
            if(m_IdleTime < -0.1f)
            {
                m_IdleTime = 2.5f;
                jumpTimes++;
            }
            else
            {
                if (_character.IsFrontBlocked||jumpTimes==3)
                {
                    _character.Flip();
                    _speed *= -1f;
                    jumpTimes = 0;
    
                }
                else
                {
                    
                    _character.Move(_speed, false, true);

                }
            }
            

        }



    }
}
