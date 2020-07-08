using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public sealed class ExitDoorReachedEventHandler : TriggerHandler
{
    public string[] _actors;
    public AudioClip _victoryAudio;
    private AudioSource _sound;
    private LevelSystem _system;

    public void Awake()
    {
        _system = GetComponent<LevelSystem>();
        _sound = GetComponent<AudioSource>();
    }

    public override void Handle(TriggerEventArgs args)
    {
        if (_actors.Contains(args.Other.tag))
        {
            // TODO: Stop player from mooving
            StartCoroutine("PlayVictory");
        }
    }

    private IEnumerator PlayVictory()
    {
        _sound.Stop();
        _sound.PlayOneShot(_victoryAudio);

        while (_sound.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(_system._nextScene);
    }
}
