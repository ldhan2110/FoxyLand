using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Cave : MonoBehaviour
{
    private Tilemap _map;
    private List<GameObject> _colliders;

    public void Awake()
    {
        _colliders = new List<GameObject>();
        _map = GetComponent<Tilemap>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_colliders.Contains(other.gameObject))
        {
            _colliders.Add(other.gameObject);
            return;
        }

        _colliders.Add(other.gameObject);

        StopCoroutine("FadeIn");
        StartCoroutine("FadeOut");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _colliders.Remove(other.gameObject);

        if (_colliders.Contains(other.gameObject))
        {
            return;
        }

        StopCoroutine("FadeOut");
        StartCoroutine("FadeIn");
    }

    private IEnumerator FadeOut()
    {
        for (float i = _map.color.a; i >= 0; i -= Time.deltaTime)
        {           
            _map.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        for (float i = _map.color.a; i < 1; i += Time.deltaTime)
        {
            _map.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
