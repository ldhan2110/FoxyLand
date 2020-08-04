using UnityEngine;
using SunnyLand;

using UnityEngine.Events;

[RequireComponent(typeof(PlatformerCharacter2D))]

public class Damagable : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;

    public string _enemyTag;
    public UnityEvent OnCollision;

    private Animator m_Anim;            // Reference to the player's animator component.

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_Character = GetComponent<PlatformerCharacter2D>();

    }
    public void OnCollisionEnter2D(Collision2D other)
    {        
        if (other.gameObject.tag == _enemyTag)
        {
            if (OnCollision != null && m_Anim.GetFloat("vSpeed") >= 0)
            {
                OnCollision.Invoke();
            }
            if(m_Anim.GetBool("isFalling"))
            {

                other.gameObject.GetComponent<PlatformerCharacter2D>().Explode();
                m_Character.Bounce();
            }
        }
    }
}
