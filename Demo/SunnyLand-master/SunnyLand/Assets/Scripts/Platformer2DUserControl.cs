using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SunnyLand.CrossPlatformInput;

namespace SunnyLand
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        public Joystick joystick;
        private bool m_Jump;
        private float h = 0;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
     
        }

        public void Jump()
        {
            m_Jump = true;
        }

        private void FixedUpdate()
        {
            // Read the inputs.

            bool crouch = Input.GetKey(KeyCode.LeftControl);

            if (joystick.Horizontal >= .3f) h = 1;
            else if (joystick.Horizontal <= -.3f) h = -1;
            else h = 0;

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
