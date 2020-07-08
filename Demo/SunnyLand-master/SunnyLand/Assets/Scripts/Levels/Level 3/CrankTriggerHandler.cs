public class CrankTriggerHandler : TriggerHandler
{
    public override void Handle(TriggerEventArgs args)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
