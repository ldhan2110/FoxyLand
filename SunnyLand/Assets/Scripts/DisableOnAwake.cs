using UnityEngine;

public class DisableOnAwake : MonoBehaviour
{
    public void Awake()
    {
        gameObject.SetActive(false);
    }
}
