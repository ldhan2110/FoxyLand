using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public string _enemyTag;
    public UnityEvent OnHurt;

    public void OnCollisionEnter2D(Collision2D other)
    {        
        if (other.gameObject.tag == _enemyTag)
        {
            if (OnHurt != null)
            {
                OnHurt.Invoke();
            }
        }
    }
}
