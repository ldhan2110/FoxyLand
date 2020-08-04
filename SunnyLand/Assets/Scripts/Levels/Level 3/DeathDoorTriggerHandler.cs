public class DeathDoorTriggerHandler : TriggerHandler
{
    public override void Handle(TriggerEventArgs args)
    {
        gameObject.gameObject.SetActive(true);
    }
}

