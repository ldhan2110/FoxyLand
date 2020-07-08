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
        private bool m_Jump, crouch;
        private float v = 0;
        private float h = 0;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            v = joystick.Vertical;
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                if(v>=.5f)
                    m_Jump = true;
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            if (v <= -.5f)
            {
                crouch = true;
            }
            else crouch = false;



            if (joystick.Horizontal >= .2f|| joystick.Horizontal <= -.2f) h = joystick.Horizontal;
            else  h = 0;

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
