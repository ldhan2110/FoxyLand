using UnityEngine;

public class GemCounter : TriggerHandler
{
    private int _total;
    private int _collected;

    private UpdateScore _score;

    public void Awake()
    {
        _total = GameObject.FindGameObjectsWithTag("Gem").Length;
        _score = FindObjectOfType<UpdateScore>();        
    }

    public void Start()
    {
        _score.UpdateText(_collected + "/" + _total);
    }

    public override void Handle(TriggerEventArgs args)
    {        
        _collected++;
       _score.UpdateText(_collected + "/" + _total);
    }
}
