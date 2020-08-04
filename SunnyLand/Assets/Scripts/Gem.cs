using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public sealed class Gem : MonoBehaviour
{
    public string[] _actors;
    public TriggerEvent TriggerEvent;

    private List<GameObject> _colliders;
    private AudioSource _audio;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    public void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        _colliders = new List<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_colliders.Contains(other.gameObject))
        {
            _colliders.Add(other.gameObject);
            return;
        }

        _colliders.Add(other.gameObject);

        if (_actors.Contains(other.gameObject.tag))
        {
            StartCoroutine("LastBreath");

            TriggerEvent.Invoke(new TriggerEventArgs(gameObject, other.gameObject));
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _colliders.Remove(other.gameObject);
    }

    private IEnumerator LastBreath()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        _audio.Play();

        while (_audio.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
