using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SunnyLand.CrossPlatformInput;
using System;
using System.IO;
using UnityEngine.UI;

namespace SunnyLand
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        public Joystick joystick;
        public float m_Health = 5f;
        public Sprite m_FullHealth,m_HalfHealth,m_EmptyHealth;
        public GameObject _Health;
        public LevelSystem _AfterDeath;

        private bool m_Jump,crouch;
        private float h = 0;
        

        private Animator m_Anim;            // Reference to the player's animator component.
        private SpriteRenderer spriteRenderer;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_Anim = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void FixedUpdate()
        {


                if (joystick.Horizontal >= .3f)
                {
                    h = 1;
                }
                else if (joystick.Horizontal <= -.3f)
                {
                    h = -1;
                }
                else
                {
                    h = 0;
                }




            if (m_Anim.GetBool("Hurt")==false)
            {
                m_Character.Move(h, crouch, m_Jump);

            }

            if(m_Health==3)
            {
                _Health.GetComponent<Image>().sprite = m_FullHealth;
            }
            else if(m_Health==2)
            {
                _Health.GetComponent<Image>().sprite = m_HalfHealth;
            }
            else if(m_Health==1)
            {
                _Health.GetComponent<Image>().sprite = m_EmptyHealth;
            }
            m_Jump = false;
        }

        public void Jump()
        {
            m_Jump = true;
        }

        public void getHurt()
        {
            m_Health -= 0.5f;
            if (m_Health <= 0)
            {
                m_Character.Explode();
            }
            else
                StartCoroutine("hurtProcess");

        }

        private IEnumerator hurtProcess()
        {
            m_Anim.SetBool("Hurt", true);

            Physics2D.IgnoreLayerCollision(12, 13, true);
            m_Character.Hurt(5f);

            yield return new WaitForSeconds(0.3f);
            m_Character.Move(0, false, false);
            m_Anim.SetBool("Hurt", false);

            spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(2f);
            Physics2D.IgnoreLayerCollision(12, 13, false);

            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

        }

        public void Death()
        {
            m_Character.Death();
        }

        public void ResetGame()
        {
            _AfterDeath.Reset();
        }

    }
}
