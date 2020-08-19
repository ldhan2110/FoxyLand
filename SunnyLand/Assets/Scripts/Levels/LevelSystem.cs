using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
