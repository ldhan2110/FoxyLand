using UnityEngine.SceneManagement;

public class PlayerReachedDeathZoneHandler : TriggerHandler
{  
    public override void Handle(TriggerEventArgs args)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
