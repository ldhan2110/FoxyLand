using System.Collections;
using UnityEngine;

namespace SunnyLand
{

    public class MovePlatform : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform _frontCheck;
        private bool _frontBlocked;
        private bool _frontBlockedByTile;

        private Rigidbody2D m_Rigidbody2D;
        public bool m_FacingRight = true;  // For determining which way the player is currently facing.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded


        private void Awake()
        {
            // Setting up references.


            _frontCheck = transform.Find("FrontCheck");
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }



        private void FixedUpdate()
        {
            if (m_Rigidbody2D == null)
                return;
            _frontBlocked = false;
            _frontBlockedByTile = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            

            Collider2D[] colliders2 = Physics2D.OverlapCircleAll(_frontCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders2.Length; i++)
            {
                if (colliders2[i].gameObject != gameObject)
                {
                    _frontBlocked = true;
                    _frontBlockedByTile = true;

                }
                if (colliders2[i].gameObject.tag == "Player")
                    _frontBlockedByTile = false;
            }

        }


        public void Move(float move)
        {
            m_Rigidbody2D.velocity = new Vector2(-move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }


        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }





        public bool IsFrontBlocked
        {
            get
            {
                return _frontBlocked;
            }
        }


        public bool IsFrontBlockedByTile
        {
            get
            {
                return _frontBlockedByTile;
            }
        }

       
    }
}
