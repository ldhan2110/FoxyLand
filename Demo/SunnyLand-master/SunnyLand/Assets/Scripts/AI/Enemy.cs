using SunnyLand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Enemy : MonoBehaviour
{
    private PlatformerCharacter2D _character;
    private float _speed = 0.1f;
    [SerializeField] private float m_IdleTime = 2.5f;
    private int jumpTimes=0;


    private void Awake()
    {
        _character = GetComponent<PlatformerCharacter2D>();
    }

    private void FixedUpdate()
    {
        if (_character.IsGrounded)
            m_IdleTime -= Time.deltaTime;
       

        if (m_IdleTime <= 0)
        {
            if(m_IdleTime < -0.1f)
            {
                m_IdleTime = 2.5f;
                _character.Move(0, false, true);
                jumpTimes++;
            }
            else
            {
                if (_character.IsFrontBlocked||jumpTimes==3)
                {
                    _character.Flip();
                    _speed *= -1f;
                    jumpTimes = 0;
                    _character.Move(0, false, true);
    
                }
                else
                {
                    
                    _character.Move(_speed, false, true);

                }
            }
            

        }



    }
}
